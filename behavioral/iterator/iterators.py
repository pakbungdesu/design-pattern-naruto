from dotenv import load_dotenv
load_dotenv()

import os
from abc import ABC, abstractmethod
from students import NinjaStudent
from sentence_transformers import SentenceTransformer, util

class INinjaIterator(ABC):
    @abstractmethod
    def has_next(self) -> bool:
        pass

    @abstractmethod
    def next(self) -> NinjaStudent:
        pass


class SortTotalScoreIterator(INinjaIterator):
    def __init__(self, students: list[NinjaStudent], descending:bool):
        self._students = sorted([s for s in students],key=lambda s: s.total_score, reverse=descending)
        self._position = 0

    def has_next(self) -> bool:
        return self._position < len(self._students)

    def next(self) -> NinjaStudent:
        if not self.has_next():
            raise StopIteration("No more ninjas found.")
        student = self._students[self._position]
        self._position += 1
        return student


class FilterTotalScoreIterator(INinjaIterator):
    def __init__(self, students: list[NinjaStudent], lower_bound:int):
            self._students = [s for s in students if s.total_score >= lower_bound]
            self._position = 0
    
    def has_next(self) -> bool:
        return self._position < len(self._students)

    def next(self) -> NinjaStudent:
        if not self.has_next():
            raise StopIteration("No more ninjas found.")
        student = self._students[self._position]
        self._position += 1
        return student


class FilterClanIterator(INinjaIterator):
    def __init__(self, students: list[NinjaStudent], clan:str):
        self._students = [s for s in students if s.clan.lower() == clan.lower()]
        self._position = 0
    
    def has_next(self) -> bool:
        return self._position < len(self._students)

    def next(self) -> NinjaStudent:
        if not self.has_next():
            raise StopIteration("No more ninjas found.")
        student = self._students[self._position]
        self._position += 1
        return student


class KeywordMatchIterator(INinjaIterator):
    def __init__(self, students: list[NinjaStudent], query: str):
        self._students = [s for s in students if query.lower() in s.description.lower()]
        self._position = 0

    def has_next(self) -> bool:
        return self._position < len(self._students)

    def next(self) -> NinjaStudent:
        if not self.has_next():
            raise StopIteration("No more ninjas found.")
        student = self._students[self._position]
        self._position += 1
        return student


class SemanticSearchIterator(INinjaIterator):
    def __init__(self, students: list[NinjaStudent], query: str, threshold: float = 0.3):

        os.environ["HF_TOKEN"] = os.getenv("HF_TOKEN", "")
        model = SentenceTransformer('all-MiniLM-L6-v2')
        
        query_embedding = model.encode(query, convert_to_tensor=True)
        descriptions = [s.description for s in students]
        desc_embeddings = model.encode(descriptions, convert_to_tensor=True)
        
        scores = util.cos_sim(query_embedding, desc_embeddings)[0]
        
        scored_students = [
            (students[i], scores[i].item()) 
            for i in range(len(students)) 
            if scores[i].item() >= threshold
        ]

        scored_students.sort(key=lambda x: x[1], reverse=True)
        self._students = [s[0] for s in scored_students]
        self._position = 0

    def has_next(self) -> bool:
        return self._position < len(self._students)

    def next(self) -> NinjaStudent:
        if not self.has_next():
            raise StopIteration("No semantically relevant ninjas found.")
        student = self._students[self._position]
        self._position += 1
        return student

    