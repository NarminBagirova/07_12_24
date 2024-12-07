namespace _07_12_24
{
    using System;

    namespace _07_12_24
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Weapon weapon = new Weapon(50, 10, FireMode.Shoot);

                    bool isRunning = true;

                    while (isRunning)
                    {
                        Console.WriteLine("Select an option:");
                        Console.WriteLine("0 - Get Information");
                        Console.WriteLine("1 - Shoot");
                        Console.WriteLine("2 - Fire");
                        Console.WriteLine("3 - Burst (3 shots)");
                        Console.WriteLine("4 - Get Remaining Bullet Count");
                        Console.WriteLine("5 - Reload");
                        Console.WriteLine("6 - Change Fire Mode");
                        Console.WriteLine("7 - Edit Weapon Settings");
                        Console.WriteLine("8 - Exit");
                        Console.WriteLine();

                        string? input = Console.ReadLine();

                        switch (input)
                        {
                            case "0":
                                Console.WriteLine($"Max Bullet Capacity: {weapon.MaxBulletCount}");
                                Console.WriteLine($"Current Bullet Count: {weapon.CurrentBulletCount}");
                                Console.WriteLine($"Current Fire Mode: {weapon.FireMode}");
                                break;

                            case "1":
                                weapon.Shoot();
                                break;

                            case "2":
                                weapon.Fire();
                                break;
                            case "3":
                                weapon.Burst();
                                break;
                            case "4":
                                Console.WriteLine($"Remaining bullets to fill the magazine: {weapon.GetRemainBulletCount()}");
                                break;
                            case "5":
                                weapon.Reload();
                                break;
                            case "6":
                                weapon.ChangeFireMode();
                                break;
                            case "7":
                                Console.WriteLine("Edit Weapon Settings:");
                                Console.WriteLine("1 - Change Max Bullet Capacity");
                                Console.WriteLine("2 - Change Current Bullet Count");
                                string editChoice = Console.ReadLine();

                                switch (editChoice)
                                {
                                    case "1":
                                        Console.Write("Enter new max bullet capacity: ");
                                        int newCapacity = int.Parse(Console.ReadLine());
                                        weapon.EditMaxCapacity(newCapacity);
                                        break;
                                    case "2":
                                        Console.Write("Enter new bullet count: ");
                                        int newBulletCount = int.Parse(Console.ReadLine());
                                        weapon.EditBulletCount(newBulletCount);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                                break;
                            case "8":
                                isRunning = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    }
                    Console.WriteLine("Exiting the program.");
                }
                catch (WeaponException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

}