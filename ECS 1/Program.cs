using System;
using System.Collections.Generic;

namespace ECS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ECS interactions
            ECS ecs = new ECS();

            //create person archetype
            ecs.createArchetype("person",
                typeof(Health),
                typeof(Name),
                typeof(IsAlive));

            //create rock archetype
            ecs.createArchetype("rock",
                typeof(Health),
                typeof(Name),
                typeof(IsAlive)
                );

            //create cat archetype
            ecs.createArchetype("cat",
                typeof(Name),
                typeof(Health),
                typeof(IsAlive),
                typeof(Cat)
                );

            Entity[] entities = new Entity[10];
            for (int i = 0; i < 10; i++)
            {
                entities[i] = ecs.createEntity();
            }
            foreach (Entity entity in entities)
            {
                Console.WriteLine(entity.id);
            }


            ecs.printArchetypes();
            ecs.printComponentIds();

            Console.ReadLine();
        }
    }
}
