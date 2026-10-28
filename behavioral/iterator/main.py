from students import GeninStudent, ChuninStudent, JoninStudent
from client import AcademyRegistry

if __name__ == "__main__":

    roster = [
        # Genin
        GeninStudent("Naruto Uzumaki", "Uzumaki", 45.0, 50.0, 42, "Loud-mouthed ninja aiming to become Hokage using shadow clones and brute chakra."),
        GeninStudent("Sasuke Uchiha", "Uchiha", 95.0, 98.0, 35, "Genius prodigy focused on gaining power and vengeance with Sharingan abilities."),
        GeninStudent("Sakura Haruno", "Haruno", 96.0, 90.0, 38, "Sharp analytical student with precise chakra control and medical aptitude."),
        GeninStudent("Hinata Hyuga", "Hyuga", 75.0, 70.0, 30, "Gentle and observant martial artist utilizing the Byakugan and gentle fist techniques."),
        GeninStudent("Rock Lee", "Lee", 30.0, 100.0, 40, "Hardworking taijutsu master lacking ninjutsu talent but possessing extreme physical stamina."),
        GeninStudent("Neji Hyuga", "Hyuga", 98.0, 99.0, 45, "Byakugan prodigy capable of shutting down enemy chakra networks with absolute precision."),
        # Chunin
        ChuninStudent("Shikamaru Nara", "Nara", 99.0, 75.0, 24.5, "Lazy tactical genius who excels at shadow manipulation and high-level battle strategy."),
        ChuninStudent("Temari", "Sand", 88.0, 88.0, 22.0, "Wind-style combatant wielding a giant folding fan for long-range area clearing."),
        ChuninStudent("Kankuro", "Sand", 80.0, 85.0, 20.0, "Puppet master strategist deploying mechanical poison-rigged combat dolls."),
        ChuninStudent("Sai", "Root", 86.0, 82.0, 23.0, "Emotionless ink-drawing artist utilizing summoned creations for reconnaissance and combat."),
        # Jonin
        JoninStudent("Kakashi Hatake", "Hatake", 100.0, 100.0, "Lightning Blade", "Experienced elite teacher and copy ninja skilled in leadership and combat tactics."),
        JoninStudent("Might Guy", "Konoha", 60.0, 100.0, "Eight Gates", "Passionate taijutsu master preaching the power of youth and extreme physical training."),
        JoninStudent("Jiraiya", "Sannin", 95.0, 98.0, "Rasengan", "Legendary toad sage combining massive chakra reserves with infiltration and jutsu mastery."),
        JoninStudent("Tsunade Senju", "Sannin", 96.0, 100.0, "Mitotic Regeneration", "Legendary medic ninja wielding monstrous super-strength and immortal healing abilities."),
        JoninStudent("Orochimaru", "Sannin", 100.0, 99.0, "Reanimation Jutsu", "Twisted scientific genius experimenting with immortality and forbidden jutsu arts."),
        JoninStudent("Itachi Uchiha", "Uchiha", 100.0, 100.0, "Tsukuyomi", "Genius rogue strategist mastering illusory realms and ultimate fire/amaterasu techniques."),
        JoninStudent("Minato Namikaze", "Namikaze", 100.0, 100.0, "Flying Raijin", "The Yellow Flash of Konoha known for unmatched speed, space-time ninjutsu, and tactical brilliance.")
    ]

    academy = AcademyRegistry(students=roster)

    print("--- 1. Sorted Total Score ---")
    it1 = academy.create_sorted_score_iterator(descending=True)
    while it1.has_next():
        print(it1.next().info())
        print("-" * 40)

    print("\n--- 2. Filter Total Score ---")
    it2 = academy.create_score_filter_iterator(lower_bound=190)
    while it2.has_next():
        print(it2.next().info())
        print("-" * 40)

    print("\n--- 3. Filter Clan ---")
    it3 = academy.create_clan_iterator(clan="Uchiha")
    while it3.has_next():
        print(it3.next().info())
        print("-" * 40)

    print("\n--- 4. Keyword match ---")
    it4 = academy.create_keyword_match_iterator("strategy")
    while it4.has_next():
        print(it4.next().info())
        print("-" * 40)

    print("\n--- 5. Semantic Search ---")
    it5 = academy.create_semantic_search_iterator("someone who is the fastest")
    while it5.has_next():
        print(it5.next().info())
        print("-" * 40)

