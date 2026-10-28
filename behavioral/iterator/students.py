
from abc import ABC, abstractmethod

class NinjaStudent(ABC):
    def __init__(self, name: str, clan: str, wt_score: float, pt_score: float, description:str):
        self.name = name
        self.clan = clan
        self.wt_score = wt_score
        self.pt_score = pt_score
        self.description = description

    def _display(self) -> str:
        return f"""[{type(self).__name__}] {self.name} ({self.clan})
Written: {self.wt_score}, Practical: {self.pt_score}
Description: {self.description}"""

    @property
    def total_score(self) -> float:
        return self.wt_score + self.pt_score

    @abstractmethod
    def info(self) -> str:
        pass
    

class GeninStudent(NinjaStudent):
    def __init__(self, name: str, clan: str, wt_score: float, pt_score: float, missions_completed: int, description:str):
        super().__init__(name, clan, wt_score, pt_score, description)
        self.missions_completed = missions_completed

    def request_mission(self) -> str:
        return f"{self.name} is requesting a D-rank mission (Completed: {self.missions_completed})."

    def _display(self) -> str:
        return f"\nD-rank Completed Missions: {self.missions_completed}"

    def info(self) -> str:
        return super()._display() + self._display()


class ChuninStudent(NinjaStudent):
    def __init__(self, name: str, clan: str, wt_score: float, pt_score: float, tactical_rating: float, description:str):
        super().__init__(name, clan, wt_score, pt_score, description)
        self.tactical_rating = tactical_rating

    def lead_squad(self) -> str:
        return f"{self.name} is commanding a 3-man squad with a {self.tactical_rating} tactical rating."

    def _display(self) -> str:
        return f"\nTactical Rating: {self.tactical_rating}"

    def info(self) -> str:
        return super()._display() + self._display()


class JoninStudent(NinjaStudent):
    def __init__(self, name: str, clan: str, wt_score: float, pt_score: float, signature_jutsu: str, description:str):
        super().__init__(name, clan, wt_score, pt_score, description)
        self.signature_jutsu = signature_jutsu

    def supervise_exam(self) -> str:
        return f"{self.name} is supervising the proctor exam using {self.signature_jutsu}."

    def _display(self) -> str:
        return f"\nSignature Jutsu: {self.signature_jutsu}"

    def info(self) -> str:
        return super()._display() + self._display()
