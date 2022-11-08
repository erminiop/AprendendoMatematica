using System;


public interface IDamageble 
{
   void TakeDamage(int damage);
   event Action DeathEvent;
   bool isDead { get; }

}
