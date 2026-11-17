
namespace Visitors
{
    using Elements;

    public interface Visitor
    {
        void VisitTaijutsuUser(TaijutsuUser t);
        void VisitNinjutsuUser(NinjutsuUser n);
        void VisitGenjutsuUser(GenjutsuUser g);
    }

    // Visitor 1 : Healer
    public class MedicalNinjaVisitor : Visitor
    {
        public void VisitTaijutsuUser(TaijutsuUser t)
        {
            ReleaseIllusionIfTrapped(t);
            t.BoneFractureCount = 0;
            t.MuscleTearSeverity = Math.Max(0, t.MuscleTearSeverity - 3);
            Console.WriteLine($"[Medical] Healed {t.Name}'s fractures. Remaining muscle tear: {t.MuscleTearSeverity}.");
        }

        public void VisitNinjutsuUser(NinjutsuUser n)
        {
            ReleaseIllusionIfTrapped(n);
            if (n.ChakraNetworkBlocked)
            {
                n.ChakraNetworkBlocked = false;
                Console.WriteLine($"[Medical] Unblocked {n.Name}'s Tenketsu chakra points.");
            }
            else
            {
                Console.WriteLine($"[Medical] {n.Name}'s chakra network is healthy.");
            }
        }

        public void VisitGenjutsuUser(GenjutsuUser g)
        {
            ReleaseIllusionIfTrapped(g);
            g.MentalFatigue = Math.Max(0, g.MentalFatigue - 40);
            Console.WriteLine($"[Medical] Stabilized {g.Name}'s mind. Mental fatigue reduced to {g.MentalFatigue}.");
        }

        private void ReleaseIllusionIfTrapped(Ninja ninja)
        {
            if (ninja.IsTrappedInIllusion)
            {
                ninja.IsTrappedInIllusion = false;
                Console.WriteLine($"[Medical] Snapped {ninja.Name} out of an enemy genjutsu.");
            }
        }
    }

    // Visitor 2: Restores stamina, chakra reserves, or mental energy
    public class ChakraInfusionVisitor : Visitor
    {
        public void VisitTaijutsuUser(TaijutsuUser t)
        {
            t.Stamina = Math.Min(100, t.Stamina + 40);
            Console.WriteLine($"[Infusion] Boosted {t.Name}'s Stamina to {t.Stamina}.");
        }

        public void VisitNinjutsuUser(NinjutsuUser n)
        {
            int bonus = (n.ChakraType == Chakra.Wind || n.ChakraType == Chakra.Fire) ? 50 : 35;
            n.CurrentChakra += bonus;
            Console.WriteLine($"[Infusion] Restored +{bonus} {n.ChakraType} chakra to {n.Name} (Total: {n.CurrentChakra}).");
        }

        public void VisitGenjutsuUser(GenjutsuUser g)
        {
            double value = new Random().NextDouble();
            if(value > 0.85)
            {
                g.IllusionDifficultyRank += 1;
            }

            Console.WriteLine($"[Infusion] Increase {g.Name}'s illusion difficulty rank to {g.IllusionDifficultyRank}.");
        }
    }

    // Visitor 3: Prisoner Officer gives power constraint on shinobi
    public class PrisonerOfficerVisitor : Visitor
    {
        public void VisitTaijutsuUser(TaijutsuUser t)
        {
            string restraint = t.Stamina > 70 ? "Heavy Chakra-Suppressing Chains" : "Standard Cuffs";
            Console.WriteLine($"[Prison] {t.Name} ({t.Village}) -> Assign {restraint} (Stamina: {t.Stamina}).");
        }

        public void VisitNinjutsuUser(NinjutsuUser n)
        {
            string status = n.ChakraNetworkBlocked ? "Safe to interrogate" : "WARNING: Using sealing immediately!";
            Console.WriteLine($"[Prison] {n.Name} ({n.ChakraType} user) -> {status}");
        }

        public void VisitGenjutsuUser(GenjutsuUser g)
        {
            string cell = g.IllusionDifficultyRank >= 4 ? "Blindfolded Isolation Cell" : "Standard Sensory-Blocked Cell";
            Console.WriteLine($"[Prison] {g.Name} -> Assign {cell}");
        }
    }

    // Visitor 4: Calculates threat score and bounty
    public class BountyRaterVisitor : Visitor
    {
        public void VisitTaijutsuUser(TaijutsuUser t)
        {
            if (t.IsTrappedInIllusion) { PrintBounty(t, 0); return; }

            double multiplier = t.JutsuName.Contains("Gate") ? 2.0 : 1.2;
            double penalty = (t.BoneFractureCount * 10) + (t.MuscleTearSeverity * 5);
            double threat = Math.Max(0, (t.Stamina * 0.6 * multiplier) - penalty);
            PrintBounty(t, threat);
        }

        public void VisitNinjutsuUser(NinjutsuUser n)
        {
            if (n.IsTrappedInIllusion || n.ChakraNetworkBlocked) { PrintBounty(n, 5); return; }

            double weight = (n.ChakraType == Chakra.Lightning || n.ChakraType == Chakra.Wind) ? 1.3 : 1.1;
            double threat = n.CurrentChakra * 0.5 * weight;
            PrintBounty(n, threat);
        }

        public void VisitGenjutsuUser(GenjutsuUser g)
        {
            if (g.IsTrappedInIllusion) { PrintBounty(g, 0); return; }

            int rankBonus = g.IllusionDifficultyRank * 10;
            double threat = ((100 - g.MentalFatigue) * 0.6) + rankBonus;
            PrintBounty(g, threat);
        }

        private void PrintBounty(Ninja ninja, double score)
        {
            string rank = score >= 90 ? "S-Rank (30M Ryo)"
                        : score >= 65 ? "A-Rank (10M Ryo)"
                        : score >= 40 ? "B-Rank (3M Ryo)"
                        : "C-Rank (500K Ryo)";

            Console.WriteLine($"[Bounty] {ninja.Name} [{ninja.JutsuName}] -> Threat: {score:F1} | {rank}");
        }
    }
}