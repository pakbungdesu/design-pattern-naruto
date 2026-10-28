from iterators import INinjaIterator
from students import GeninStudent, ChuninStudent, JoninStudent
from ninja_collections import GeninCollection, ChuninCollection, JoninCollection, StudentCollection

if __name__ == "__main__":

    def client(it: INinjaIterator) -> None:
        while it.has_next():
            print(it.next().info())
            print("-" * 40)

    genin = [
        GeninStudent("Naruto Uzumaki", "Uzumaki", 45.0, 50.0, 42, "Loud-mouthed ninja aiming to become Hokage using shadow clones and brute chakra."),
        GeninStudent("Sasuke Uchiha", "Uchiha", 95.0, 98.0, 35, "Genius prodigy focused on gaining power and vengeance with Sharingan abilities."),
        GeninStudent("Sakura Haruno", "Haruno", 96.0, 90.0, 38, "Sharp analytical student with precise chakra control and medical aptitude."),
        GeninStudent("Hinata Hyuga", "Hyuga", 75.0, 70.0, 30, "Gentle and observant martial artist utilizing the Byakugan and gentle fist techniques."),
        GeninStudent("Rock Lee", "Lee", 30.0, 100.0, 40, "Hardworking taijutsu master lacking ninjutsu talent but possessing extreme physical stamina.")
    ]

    neji = GeninStudent("Neji Hyuga", "Hyuga", 98.0, 99.0, 45, "Byakugan prodigy capable of shutting down enemy chakra networks with absolute precision.")

    chunin = [
        ChuninStudent("Shikamaru Nara", "Nara", 99.0, 75.0, 24.5, "Lazy tactical genius who excels at shadow manipulation and high-level battle strategy."),
        ChuninStudent("Temari", "Sand", 88.0, 88.0, 22.0, "Wind-style combatant wielding a giant folding fan for long-range area clearing."),
        ChuninStudent("Kankuro", "Sand", 80.0, 85.0, 20.0, "Puppet master strategist deploying mechanical poison-rigged combat dolls."),
        ChuninStudent("Sai", "Root", 86.0, 82.0, 23.0, "Emotionless ink-drawing artist utilizing summoned creations for reconnaissance and combat.")
    ]
    
    jonin = [
        JoninStudent("Kakashi Hatake", "Hatake", 100.0, 100.0, "Lightning Blade", "Experienced elite teacher and copy ninja skilled in leadership and combat tactics."),
        JoninStudent("Might Guy", "Konoha", 60.0, 100.0, "Eight Gates", "Passionate taijutsu master preaching the power of youth and extreme physical training."),
        JoninStudent("Jiraiya", "Sannin", 95.0, 98.0, "Rasengan", "Legendary toad sage combining massive chakra reserves with infiltration and jutsu mastery."),
    ]

    jonin2 = [
        JoninStudent("Tsunade Senju", "Sannin", 96.0, 100.0, "Mitotic Regeneration", "Legendary medic ninja wielding monstrous super-strength and immortal healing abilities."),
        JoninStudent("Orochimaru", "Sannin", 100.0, 99.0, "Reanimation Jutsu", "Twisted scientific genius experimenting with immortality and forbidden jutsu arts."),
        JoninStudent("Itachi Uchiha", "Uchiha", 100.0, 100.0, "Tsukuyomi", "Genius rogue strategist mastering illusory realms and ultimate fire/amaterasu techniques."),
        JoninStudent("Minato Namikaze", "Namikaze", 100.0, 100.0, "Flying Raijin", "The Yellow Flash of Konoha known for unmatched speed, space-time ninjutsu, and tactical brilliance.")
    ]

    print("\n--- 1. Genin (No Neji) ---")
    genin_col = GeninCollection(genin)
    it = genin_col.create_score_filter_iterator(lower_bound=190)
    client(it)

    print("\n--- 2. Genin (Add Neji) ---")
    genin_col.add_student(neji)
    it = genin_col.create_score_filter_iterator(lower_bound=190)
    client(it)

    print("\n--- 3. Chunin (Search 'Sand') ---")
    chunin_col = ChuninCollection(chunin)
    it = chunin_col.create_clan_iterator("Sand")
    client(it)

    print("\n--- 4. Keyword match (Search 'strategy') ---")
    it = chunin_col.create_keyword_match_iterator("strategy")
    client(it)

    print("\n--- 5. Semantic Search 1 for Jonin ---")
    jonin_col = JoninCollection(jonin)
    it = jonin_col.create_semantic_search_iterator("who is the most genius")
    client(it)

    print("\n--- 6. Semantic Search 2 for Jonin ---")
    jonin_col.add_students(jonin2)
    it = jonin_col.create_semantic_search_iterator("who is the most genius")
    client(it)

    all_students = StudentCollection(genin)
    all_students.add_student(neji)
    all_students.add_students(chunin)
    all_students.add_students(jonin)
    all_students.add_students(jonin2)

    print("\n--- 7. Sort Total Score for All Students ---")
    it = all_students.create_sorted_score_iterator(descending=True)
    client(it)

    print("\n--- 8. Semantic Search for All Students ---")
    it = all_students.create_semantic_search_iterator("who is the most genius")
    client(it)
