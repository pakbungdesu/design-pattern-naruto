namespace mediators
{
    using colleagues;

    public interface ISummitProtection
    {
        void Notify(Ninja sender, string message, int winrate = 100);
        int EvaluateCombatPower(List<Enemy> incomingEnemies, string whichteam);
    }
    
    public class SummitMediator : ISummitProtection
    {
        private List<TankNinja> _tanks = new();
        private List<AnbuNinja> _anbus = new();
        private List<MedicalNinja> _medics = new();
        
        public void AddTank(TankNinja tank) => _tanks.Add(tank);
        public void AddAnbu(AnbuNinja anbu) => _anbus.Add(anbu);
        public void AddMedic(MedicalNinja medic) => _medics.Add(medic);

        public void Notify(Ninja sender, string message, int winrate = 100)
        {
            Console.WriteLine($"[SummitMediator] Broadcast from {sender.Name} at [{sender.Location}]: {message}");

            // SITUATION 1: Tank Sender (Invasion Detected)
            if (message == "invasion detected" && sender is TankNinja)
            {
                Console.WriteLine("[Multi-Party Coordination]: Tank frontline breached! Mobilizing all defense lines.");

                foreach (var tank in _tanks)
                {
                    if (tank != sender)
                    {
                        tank.Location = sender.Location;
                        tank.Ready = true;
                    }
                }

                LoopFight("tank");
                SetReady(true, "medic");
                SetReady(true, "anbu");
            }
            // SITUATION 2: Tank Sender (Active Combat & Evacuation)
            else if (message == "tank is fighting" && sender is TankNinja && winrate < 60)
            {
                if (sender.Location == "hall")
                {
                    Console.WriteLine("[Multi-Party Coordination]: Hall defense failing! Executing simultaneous 3-way evacuation protocol.");
                    
                    SetLocation("rooftop", "tank");
                    LoopEvacuate("helicopter", "tank");

                    SetLocation("rooftop", "anbu");
                    LoopEvacuate("helicopter", "anbu");
                    LoopFight("anbu");

                    SetLocation("rooftop", "medic");
                    LoopEvacuate("helicopter", "medic");
                }
                else if (sender.Location == "rooftop")
                {
                    Console.WriteLine("[Multi-Party Coordination]: Rooftop breach! Coordinating water extraction.");
                    
                    SetLocation("dock", "tank");
                    LoopEvacuate("armor boat", "tank");

                    SetLocation("dock", "anbu");
                    LoopEvacuate("armor boat", "anbu"); 
                    LoopFight("anbu");

                    SetLocation("dock", "medic");
                    LoopEvacuate("armor boat", "medic"); 
                } 
                else
                {
                    Console.WriteLine("[Multi-Party Coordination]: Outside breach! Coordinating various extraction.");

                    SetLocation("dock", "tank");
                    LoopEvacuate("armor boat", "tank");

                    SetLocation("rooftop", "anbu");
                    LoopEvacuate("helicopter", "anbu");
                    LoopFight("anbu");

                    SetLocation("rooftop", "medic");
                    LoopEvacuate("helicopter", "medic");
                }
            }
            // SITUATION 3: ANBU Sender (Perimeter Breach / Recon Alert)
            else if (message == "perimeter breached" && sender is AnbuNinja)
            {
                Console.WriteLine($"[Multi-Party Coordination]: ANBU unit {sender.Name} spotted flank attack at [{sender.Location}]! All units shift formation.");

                SetReady(true, "tank");
                SetLocation(sender.Location, "tank");
                LoopFight("tank");

                SetReady(true, "medic");
            }
            else if (message == "anbu is fighting" && sender is AnbuNinja && winrate < 60)
            {
                if (sender.Location == "hall")
                {
                    Console.WriteLine("[Multi-Party Coordination]: ANBU sector in Hall failing! Executing tactical fallback and medical extraction.");
                    
                    SetLocation("rooftop", "anbu");
                    LoopEvacuate("helicopter", "anbu");

                    SetLocation("rooftop", "tank");
                    LoopFight("tank");
                    LoopEvacuate("helicopter", "tank");

                    SetLocation("rooftop", "medic");
                    LoopEvacuate("helicopter", "medic"); 
                }
                else if (sender.Location == "rooftop")
                {
                    Console.WriteLine("[Multi-Party Coordination]: ANBU sector on Rooftop overwhelmed! Coordinating maritime extraction.");
                    
                    SetLocation("dock", "anbu");
                    LoopEvacuate("armor boat", "anbu");

                    SetLocation("dock", "tank");
                    LoopFight("tank");
                    LoopEvacuate("armor boat", "tank");

                    SetLocation("dock", "medic");
                    LoopEvacuate("armor boat", "medic");
                } 
                else
                {
                    Console.WriteLine("[Multi-Party Coordination]: Outside breach! Coordinating various extraction.");

                    SetLocation("rooftop", "tank");
                    LoopEvacuate("helicopter", "tank");

                    SetLocation("dock", "anbu");
                    LoopEvacuate("armor boat", "anbu");

                    SetLocation("dock", "medic");
                    LoopEvacuate("armor boat", "medic");
                }
            }
            // SITUATION 4: Tank injuries
            else if (message == "tank critical injuries" && sender is TankNinja)
            {
                Console.WriteLine($"[Multi-Party Coordination]: Tank {sender.Name} reports heavy casualties.");
                
                SetLocation(sender.Location, "medic");
                Console.WriteLine("[Tactical Shift]: All medic units move to the tank injuries");
                if (_medics.Count > 0)
                {
                    Random rand = new Random();
                    int randomIndex = rand.Next(0, _medics.Count); // upper bound is exclusive
                    HealThis(sender, randomIndex);
                }
            }
            // SITUATION 4: Anbu injuries
            else if (message == "anbu critical injuries" && sender is AnbuNinja)
            {
                Console.WriteLine($"[Multi-Party Coordination]: Anbu {sender.Name} reports heavy casualties.");
                
                SetLocation(sender.Location, "medic");
                Console.WriteLine("[Tactical Shift]: All medic units move to the anbu injuries");
                if (_medics.Count > 0)
                {
                    Random rand = new Random();
                    int randomIndex = rand.Next(0, _medics.Count); // upper bound is exclusive
                    HealThis(sender, randomIndex);
                }
            }
            // SITUATION 5: Medical needs cover
            else if (message == "Medic needs covering" && sender is MedicalNinja)
            {
                Console.WriteLine($"[Multi-Party Coordination]: Medic {sender.Name} reports heavy casualties and need covering");
                
                SetLocation(sender.Location, "tank");
                Console.WriteLine("[Tactical Shift]: Tank units move to cover the medic");
                LoopFight("tank");
            }
            // SITUATION 6: General Backup Request (Any Sender)
            else if (message == "request backup")
            {
                Console.WriteLine($"[Multi-Party Coordination]: General backup requested at [{sender.Location}].");
                SetReady(true, "anbu");
                SetLocation(sender.Location, "anbu");
            }
            // SITUATION 7: Finish
            else if (message == "finish")
            {
                SetReady(false, "tank");
                SetReady(false, "anbu");

                SetReady(true, "medic");
                LoopHeal();
            }
        }

        public int EvaluateCombatPower(List<Enemy> enemies, string whichteam)
        {            
            Console.WriteLine($"[Power Comparison] Route: {enemies[0].Location}");
            SetLocation(enemies[0].Location, whichteam);

            List<ICombatant> team;
            if (whichteam == "tank")
            {
                team = _tanks.Cast<ICombatant>().ToList();
            } 
            else if (whichteam == "anbu")
            {
                team = _anbus.Cast<ICombatant>().ToList();
            } 
            else 
            {
                team = _medics.Cast<ICombatant>().ToList();
            }

            int totalProtectorAttack = CalculateTotalAttack(team);
            int totalEnemyAttack = CalculateTotalAttack(enemies.Cast<ICombatant>().ToList());

            Console.WriteLine($"[Summary Stats] Total Protector Attack: {totalProtectorAttack} vs Total Enemy Attack: {totalEnemyAttack}");

            int winrate = CalculateWinrate(totalEnemyAttack, totalProtectorAttack);
            return winrate;
        }

        public void LoopFight(string whichteam)
        {
            if (whichteam == "tank")
            {
                foreach(var ninja in _tanks) { ninja.Fight(); }
            } 
            else if (whichteam == "anbu")
            {
                foreach(var ninja in _anbus) { ninja.Fight(); }
            } 
            else 
            {
                foreach(var ninja in _medics) { ninja.Fight(); }
            }
        }

        private void LoopEvacuate(string vehicle, string whichteam)
        {
            if (whichteam == "tank")
            {
                foreach(var ninja in _tanks) { ninja.Evacuate(vehicle); }
            } 
            else if (whichteam == "anbu")
            {
                foreach(var ninja in _anbus) { ninja.Evacuate(vehicle); }
            } 
            else 
            {
                foreach(var ninja in _medics) { ninja.Evacuate(vehicle); }
            }
        }

        private void SetLocation(string route, string whichteam)
        {
            if (whichteam == "tank")
            {
                foreach(var ninja in _tanks) { ninja.Location = route; }
            } 
            else if (whichteam == "anbu")
            {
                foreach(var ninja in _anbus) { ninja.Location = route; }
            } 
            else 
            {
                foreach(var ninja in _medics) { ninja.Location = route; }
            }
        }

        private void SetReady(bool ready, string whichteam)
        {
            if (whichteam == "tank")
            {
                foreach(var ninja in _tanks) { ninja.Ready = ready; }
            } 
            else if (whichteam == "anbu")
            {
                foreach(var ninja in _anbus) { ninja.Ready = ready; }
            } 
            else 
            {
                foreach(var ninja in _medics) { ninja.Ready = ready; }
            }
        }

        private void HealThis(Ninja sender, int medicIdx)
        {
            if (_medics.Count > medicIdx)
            {
                _medics[medicIdx].Location = sender.Location;
                _medics[medicIdx].Healing(sender);
            }
        }

        private void LoopHeal()
        {
            List<Ninja> patients = [.. _tanks, .. _anbus];

            if (_medics.Count == 0 || patients.Count == 0)
            {
                Console.WriteLine("[Medical Standby] No medics or patients available for treatment.");
                return;
            }

            for (int i = 0; i < patients.Count; i++)
            {
                var medic = _medics[i % _medics.Count];
                var patient = patients[i];

                medic.Location = patient.Location;
                medic.Healing(patient);
            }
        }

        private int CalculateTotalAttack(List<ICombatant> combatants)
        {
            return combatants.Sum(c => c.Attack);
        }

        private int CalculateWinrate(int totalEnemyAttack, int totalProtectorAttack)
        {
            double attackRatio = totalEnemyAttack > 0 ? (double)totalProtectorAttack / totalEnemyAttack : 2.0;
            double avgEndurance = _tanks.Count > 0 ? _tanks.Average(t => t.Endurance) : 50.0;

            double winrate = (Math.Min(attackRatio, 2.0) / 2.0 * 60.0) + (avgEndurance * 0.4);

            if (winrate > 100.0) winrate = 100.0;
            if (winrate < 0.0) winrate = 0.0;

            Console.WriteLine($"[Combat Evaluation] Calculated Winrate: {winrate:F2}%");

            return (int)winrate;
        }
    }
}