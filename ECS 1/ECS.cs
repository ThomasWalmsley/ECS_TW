using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_1
{
    class ECS
    {
        //STORAGE SECTION
        int id; //used to give every entity a unique id
                //Archetype[] archetypeStorage = new Archetype[100];
                // Dictionary<List<Type>, ValueType[]> archetypes = new Dictionary<List<Type>, ValueType[]>();
        Dictionary<string, ValueType[]> archetypes = new Dictionary<string, ValueType[]>();//where string is a hash(?) of a list of components 
        Dictionary<string, string> archetypeNames = new Dictionary<string, string>();//where one string is name, and other string is a hash(?) of a list of components 

        Dictionary<Type, int> ComponentTypeId = new Dictionary<Type, int>();//used to order components of different type
        Dictionary<int, Type> InverseComponentTypeID = new Dictionary<int, Type>();//used to turn int back into component type

        //PUBLIC LOGIC SECTION
        public void createArchetype(string Name, params Type[] components)
        {
            //new code
            //hash input components
            string hashComponents = hashListofComponents(components);
            //is hash already a key?
            if (archetypes.ContainsKey(hashComponents))
            {
                Console.WriteLine("archetype already exists with these components");
                return;
            }
            if (archetypeNames.ContainsKey(Name))
            {
                Console.WriteLine("an existing archetype is already using this name : " + Name);
                return;
            }
            archetypes.Add(hashComponents, new ValueType[100]);
            archetypeNames.Add(Name, hashComponents);

            Console.WriteLine("archetype created");




            //old code


            //    List<Type> componentsList = components.OfType<Type>().ToList();
            //    //order list so it can be compared to other archetypes
            //    List<Type> orderedList = orderComponents(componentsList);
            //    //Enumerable.SequenceEqual(list1, list2);
            //    if (archetypes.Count != 0) 
            //    {
            //        Console.WriteLine("archetype 0 = " + archetypes.ElementAt(0));
            //        //hashordered list is guaranteed to be unique if there are no other archetypes
            //        //var hashArchetype = archetypes[hashOrderedList];
            //        if (archetypes.ContainsKey(orderedList))
            //        {
            //            //if key exists, we don't need to add an archetype
            //            Console.WriteLine("archetype already exists");
            //            return;
            //        }
            //        //Console.WriteLine("hash archetype : " + hashArchetype);
            //    }          
            //    
            //    //check if archetype is already in archetypes (archetype storage)

            //  if (archetypeNames.ContainsKey(Name))
            //  {
            //      Console.WriteLine("an existing archetype is already using this name : " + Name);
            //      return;
            //  }
            // archetypes.Add(orderedList, new ValueType[100]);
            // archetypeNames.Add(Name, orderedList);
            // //archetypeStorage[]

            // Console.WriteLine("archetype created");


        }

        public Entity createEntity()
        {
            Entity entity = new Entity(id++);
            return entity;
        }

        public void addComponents(int entityId, params Type[] components)
        {
            //find entity

            //add components

            //check which archetype the entity fits under

            //if it fits no archetype, create new archetype
        }

        public void setArchetype(int entityId, string archetypeName)
        {
            //find entity

            //find components somehow?

            //hash components

            //check hash with archetype dictionary

            //if hash is unique, add 
        }

        //PRIVATE LOGIC SECTION

        private void checkComponentInDict(Type componentType)
        {
            if (!(ComponentTypeId.ContainsKey(componentType)))
            {
                //if component type is unknown, add it to ComponentTypeId

                int count = ComponentTypeId.Count;
                ComponentTypeId.Add(componentType, count);
                InverseComponentTypeID.Add(count, componentType);
            }
        }
        private string hashListofComponents(Type[] components)
        {
            //Summary - take an array and create a hash of it. 
            string hash = "";
            foreach (Type componentType in components)
            {
                checkComponentInDict(componentType);
                string name = componentType.Name;

                char firstchar = name[0];
                int id = ComponentTypeId[componentType];

                hash = hash + firstchar + id;
            }
            return hash;
        }
        private List<Type> orderComponents(Type[] components)
        {
            List<int> ids = new List<int>();
            foreach (Type componentType in components)
            {
                checkComponentInDict(componentType);
                ids.Add(ComponentTypeId[componentType]);
            }
            ids.Sort();
            List<Type> orderedList = new List<Type>();
            foreach (int id in ids)
            {
                orderedList.Add(InverseComponentTypeID[id]);
            }
            Console.WriteLine("components ordered");
            return orderedList;
        }




        //VISUALS SECTION


        public void printArchetypes()
        {
            Console.WriteLine("Archetypes:");
            //print all archetypes
            foreach (KeyValuePair<string, string> archetype in archetypeNames)
            {
                Console.WriteLine("   "+archetype.Key);
            }
        }
        public void printComponentIds()
        {
            Console.WriteLine("Component Type Ids:");
            foreach (KeyValuePair<Type, int> component in ComponentTypeId)
            {
                Console.WriteLine("   " + component.Key.Name + " : " + component.Value);
            }
        }
    }
}
