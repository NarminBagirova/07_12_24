using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_12_24
{
    public class Weapon
    {
        private int _maxBulletCount;
        private int _currentBulletCount;
        private FireMode _fireMode;

        public int MaxBulletCount => _maxBulletCount; 
        public int CurrentBulletCount => _currentBulletCount;
        public FireMode FireMode => _fireMode;

        public Weapon(int maxBulletCount, int currentBulletCount, FireMode fireMode)
        {
            if (maxBulletCount <= 0 || currentBulletCount < 0 || currentBulletCount > maxBulletCount)
                throw new WeaponException("Invalid value: Max bullet count must be positive and current bullet count must be between 0 and max bullet count");

            _maxBulletCount = maxBulletCount;
            _currentBulletCount = currentBulletCount;
            _fireMode = fireMode;
        }

        public void Shoot()
        {
            try
            {
                if (_fireMode == FireMode.Shoot) 
                {
                    if (_currentBulletCount > 0)
                    {
                        _currentBulletCount--;
                        Console.WriteLine("One bullet fired");
                    }
                    else
                    {
                        throw new WeaponException("No bullets left to shoot");
                    }
                }
                else
                {
                    Console.WriteLine("Current fire mode is not set to Shoot.");
                }
            }
            catch (WeaponException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void Fire()
        {
            try
            {
                if (_currentBulletCount > 0)
                {
                    Console.WriteLine("All bullets fired.");
                    _currentBulletCount = 0;
                }
                else
                {
                    throw new WeaponException("No bullets to fire.");
                }
            }
            catch (WeaponException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void Burst()
        {
            try
            {
                if (_fireMode == FireMode.Burst) 
                {
                    if (_currentBulletCount >= 3)
                    {
                        _currentBulletCount -= 3;
                        Console.WriteLine("Three bullets fired in burst");
                    }
                    else
                    {
                        throw new WeaponException("Not enough bullets for burst fire! 3 bullets are required.");
                    }
                }
                else
                {
                    Console.WriteLine("Current fire mode is not set to Burst.");
                }
            }
            catch (WeaponException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public int GetRemainBulletCount()
        {
            return _maxBulletCount - _currentBulletCount;
        }

        public void Reload()
        {
            try
            {
                _currentBulletCount = _maxBulletCount;
                Console.WriteLine("Magazine reloaded");
            }
            catch (WeaponException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void ChangeFireMode()
        {
            try
            {
                Console.WriteLine("\nSelect a fire mode to change to:");
                Console.WriteLine("1. Shoot (Single shot)");
                Console.WriteLine("2. Fire (Automatic fire)");
                Console.WriteLine("3. Burst (3 shots)");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _fireMode = FireMode.Shoot;
                        Console.WriteLine("Fire mode changed to: Shoot (Single shot)");
                        break;

                    case "2":
                        _fireMode = FireMode.Fire;
                        Console.WriteLine("Fire mode changed to: Fire (Automatic fire)");
                        break;
                    case "3":
                        _fireMode = FireMode.Burst;
                        Console.WriteLine("Fire mode changed to: Burst (3 shots)");
                        break;

                    default:
                        throw new WeaponException("Invalid selection. Please select a valid option.");
                }
            }
            catch (WeaponException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void EditMaxCapacity(int newCapacity)
        {
            try
            {
                if (newCapacity <= 0) throw new WeaponException("Max capacity must be a positive numbr.");

                        _maxBulletCount = newCapacity;

                Console.WriteLine($"Capacity updated to {_maxBulletCount}");
            }
            catch (WeaponException ex) { Console.WriteLine($"{ex.Message}"); }
        }

        public void EditBulletCount(int newBulletCount)
        {
            try
            {
                if (newBulletCount <= 0 || newBulletCount > _maxBulletCount)
                    throw new WeaponException("Bullet count must be between 0 and max bullet count");

                _currentBulletCount = newBulletCount;
                Console.WriteLine($"Bullet count updated to {_currentBulletCount}");
            }
            catch (WeaponException ex) { Console.WriteLine($"{ex.Message}"); }
        }

    }
}
