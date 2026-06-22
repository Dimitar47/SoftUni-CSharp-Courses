using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;

            List<ISoldier> soldiers = new List<ISoldier>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];

                ISoldier soldier;

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    List<string> ids = tokens.Skip(5).ToList();
                    List<IPrivate> privates = new List<IPrivate>();

                    foreach (var privateId in ids)
                    {
                        IPrivate @private = (IPrivate)soldiers.FirstOrDefault(x => x.Id == privateId);
                        privates.Add(@private);
                    }
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        decimal salary = decimal.Parse(tokens[4]);
                        string corps = tokens[5];
                        List<string> strings = tokens.Skip(6).ToList();
                        List<IRepair> repairs = new List<IRepair>();
                        for (int i = 0; i < strings.Count; i += 2)
                        {
                            IRepair repair = new Repair(strings[i], int.Parse(strings[i + 1]));
                            repairs.Add(repair);

                        }
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }
                    catch (ArgumentException ex)
                    {
                        continue;
                    }

                }
                else if (type == "Commando")
                {
                    try
                    {
                        decimal salary = decimal.Parse(tokens[4]);
                        string corps = tokens[5];

                        List<string> strings = tokens.Skip(6).ToList();
                        List<IMission> missions = new List<IMission>();

                        for (int i = 0; i < strings.Count; i += 2)
                        {
                            try
                            {
                                IMission mission = new Mission(strings[i], strings[i + 1]);
                                missions.Add(mission);
                            }
                            catch (ArgumentException)
                            {
                                continue;
                            }

                        }
                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
                else
                {
                    int codeNumber = int.Parse(tokens[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);

                }


                soldiers.Add(soldier);
            }


            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }

        }
    }
}
