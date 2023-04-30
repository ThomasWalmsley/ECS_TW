using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_1
{
    class ECS
    {
        Dictionary<List<Type>, ValueType[]> archetypes = new Dictionary<List<Type>, ValueType[]>();
        Dictionary<string, List<Type>> archetypeNames = new Dictionary<string, List<Type>>();

        Dictionary<Type, int> ComponentTypeId = new Dictionary<Type, int>();//used to order components of different type
        Dictionary<int,Type> InverseComponentTypeID = new Dictionary<int, Type>();//used to turn int back into component type

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
            //Summary//
            //Order the components to make sure two archetypes aren't made out of the same components in different orders
            //
            //make a list of componentTypeIds (ints to allow ordering)
            List<int> ids = new List<int>();
            //check components are in ComponentTypeId
            foreach (Type componentType in componentsList) 
            {
                if (!(ComponentTypeId.ContainsKey(componentType))) 
                {
                    //if component type is unknown, add it to ComponentTypeId

                    int count = ComponentTypeId.Count;
                    ComponentTypeId.Add(componentType, count);
                    InverseComponentTypeID.Add(count, componentType);
                }
                int id = ComponentTypeId[componentType];
                ids.Add(id);
            }
            
            //order list
            ids.Sort();
            //create new list of component types according to component ids
            List<Type> orderedList = new List<Type>();
            foreach(int id in ids) 
            {
                orderedList.Add(InverseComponentTypeID[id]);
            }

            Console.WriteLine("components ordered");
            return orderedList;
        }

        public void getArchetype(string Name) 
        {
            //get all entities of this archetype
            //Archetype
        }
    }
}
