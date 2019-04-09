Technologies used: EF MVC Core 

UI: Mvc/CSS/Bootstrap
Database: SQL server Management Studio 2017
ORM: EF Core Db first 	

SQL Table scripts:
Checked in table scripts under VMS/DbScripts folder for your reference. Also, checked-in insert scripts for few tables which will help populate dropdowns

SUMMARY:

The solution provided enables you to select a vehicle type and create a new record. Also, you can view all records and delete any record.

There are VehicleType and VehicleProperties tables which are mapped in VehicleTypeProperties table. So, you can add properties without repeating/creating duplicate property name for any vehicle type. In addition, the mapping can be enabled/disabled based on the IS_ACTIVE property.

Similarly, for each Vehicle type, there are Vehicle_Make and Vehicle_Model tables which are mapped in Vehicle_MakeModel_Mapping table. Again, each mapping can be enabed/disabled based on the IS_Active property.

For each Vehicle type, the make-model-mapping is saved in the Vehicle_Records table. And the property values are saved in the Vehicle_Records_Properties table.

This gives a scalable approach and we can add/delete Vehicles and it's properties anytime with minimum changes.

I have added some basic error handling.

I have tried maintaining clean code as much as possible. Also, I have separated all logical groups in separate classes.
