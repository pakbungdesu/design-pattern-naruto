from students import NinjaStudent
from iterators import (
    SortTotalScoreIterator,
    FilterTotalScoreIterator,
    FilterClanIterator,
    KeywordMatchIterator,
    SemanticSearchIterator
)

class AcademyRegistry:
    def __init__(self, students: list[NinjaStudent] = None):
        self._students = students if students else []

    def add_student(self, student: NinjaStudent) -> None:
        self._students.append(student)

    def create_sorted_score_iterator(self, descending: bool = True) -> SortTotalScoreIterator:
        return SortTotalScoreIterator(self._students, descending)

    def create_score_filter_iterator(self, lower_bound: float) -> FilterTotalScoreIterator:
        return FilterTotalScoreIterator(self._students, lower_bound)

    def create_clan_iterator(self, clan: str) -> FilterClanIterator:
        return FilterClanIterator(self._students, clan)

    def create_keyword_match_iterator(self, query: str) -> KeywordMatchIterator:
        return KeywordMatchIterator(self._students, query)

    def create_semantic_search_iterator(self, query: str, threshold: float = 0.3) -> SemanticSearchIterator:
        return SemanticSearchIterator(self._students, query, threshold)
    