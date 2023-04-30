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
            ecs.createArchetype("person", new List<Type> { typeof(Health), typeof(Name) });



            //Boring tests








            Dictionary<List<Type>, ValueType[]> archetypes = new Dictionary<List<Type>, ValueType[]>();

            //Player archetype
            List<Type> list1 = new List<Type>();

            //Cat archetype
            List<Type> list2 = new List<Type>();

            //Monster archetype
            List<Type> list3 = new List<Type>();

            //create archetype name
            list1.Add(typeof(Health));
            list1.Add(typeof(Name));
            list1.Add(typeof(IsAlive));


            //add archetype to dictionary
            archetypes.Add(list1, new ValueType[100]);


            //get array from dictionary to edit the array
            var array = archetypes[list1];

            //edit array
            array[0] = new Health(4);

            //print
            Console.WriteLine(array[0]);


            Console.ReadLine();
        }
    }
}
