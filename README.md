# SAPServer
This web API was developed in SOAP Communication Pattern so that it can be used by other client application for the project "ItaliaPizza"


# Pre-requisites

Add this property in the complex entity [ECliente]
Property: public List<EDireccion> Direcciones { get; set; }
  
Add this property in the complex entity [EReceta]
Property: public List<EIngrediente> Ingredientes { get; set; }
  
Database for local deployment
SapDatabase.bak -> path: C:..\SAPServer\Base de datos\SAPDataBase.bak
