namespace _06.MoneyTransactions
{
    public class Program
    {
        public static void Main(string[] args)
        {


            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> dict = new Dictionary<int, double>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] pair = input[i].Split("-", StringSplitOptions.RemoveEmptyEntries);
                int accountNumber = int.Parse(pair[0]);
                double balance = double.Parse(pair[1]);

                if (!dict.ContainsKey(accountNumber))
                {
                    dict.Add(accountNumber, balance);
                }
            }

            string command;

            while((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                int account = int.Parse(tokens[1]);
                double balance = double.Parse(tokens[2]);

                try
                {
                    if (action == "Deposit")
                    {
                        dict[account] += balance;
                    }
                    else if (action == "Withdraw")
                    {
                        if (balance > dict[account])
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }
                        dict[account] -= balance;

                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {account} has new balance: {dict[account]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(KeyNotFoundException ex)
                {
                    Console.WriteLine("Invalid account!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }



        }
    }
}
