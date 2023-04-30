Notes:
Description:
	This is an Entity Component System (ECS) for use in my RPG.
	Entities are identifiers, components are data, systems handle the data
	Arrays are used to store which components are associated with which entities
	Archetypes are a way to group entities by the components they have. e.g Person archetype could be all entities that have only Health,Mana,Human components


What the program does so far:

	can create archetypes 
		archetypes cannot have exactly the same components
		archetypes cannot have the same name

	archetype information is stored in two dictionaries
		"archetypes" uses a hash of the archetypes' components as a key, and the value is an array (which should in the future store entities of this archetype?)
		"archetypeNames" uses a string name as a key, and the archetype hash as a value. This allows using a name to get a hash key for the "archetypes" dictionary 
	
	Component Types are given unique ids (ints) so they can be ordered
	
	Components are structs
		Methods that handle struct expect a variable of type Type. This could be anything, no type checking is done :(

What the program needs:
	Entity creation
	Multiple Arrays (dynamically create an array for every component in an archetype)
	Queries 
	dynamic archetype generation (when an entity of archetype person has an extra component added, it should be placed in a new archetype e.g. person-with-one-leg)
	
	read json file and create archetypes out of it



