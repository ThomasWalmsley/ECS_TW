using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_1
{
    class ECS
    {
        Dictionary<List<Type>, ValueType[]> archetypes = new Dictionary<List<Type>, ValueType[]>();
        Dictionary<string, List<Type>> archetypeNames = new Dictionary<string, List<Type>>();

        public void createArchetype(string Name,List<Type> componentsList) 
        {
            //order list so it can be compared to other archetypes
            List<Type> orderedList = orderComponents(componentsList);
            //check if archetype is already in archetypes (archetype storage)
            if (archetypes.ContainsKey(componentsList)) 
            {
                //if key exists, we don't need to add an archetype
                Console.WriteLine("archetype already exists");
                return;
            }
            if (archetypeNames.ContainsKey(Name)) 
            {
                Console.WriteLine("an existing archetype is already using this name : " + Name);
                return;
            }
            archetypes.Add(orderedList, new ValueType[100]);
            archetypeNames.Add(Name, orderedList);

            Console.WriteLine("archetype created");


        }

        private List<Type> orderComponents(List<Type>componentsList) 
        {
            //Order the components to make sure two archetypes aren't made out of the same components in different orders
            Console.WriteLine("no ordering implemented :(");
            return componentsList;
        }

        public void getArchetype(string Name) 
        {
            //get all entities of this archetype

        }
    }
}
