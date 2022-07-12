# Banco
Prueba técnica
Instrucciones:

1. Abrir en visual studio 2022.
Arquitectura:
Servicio
  Banco.Core(Entities, interfaces, definitions)
  Banco.DataAccess(DbContext, ConfigurationEntities, Migrations, Repositories, UnitOfWork)
  Banco.Rest(ServicioRest)
  Banco.Services(BusinessLogic)
Cleinte
  Banco.Web(Aplicacion de cliente)
  
2. Click derecjo solución>Propiedades y configurar multiples proyectos de inicio como en la imagen:
![image](https://user-images.githubusercontent.com/4412640/178529422-2ff492ea-b5de-4344-9e2e-2aedd915ab5f.png)

3. Presionar ejecutar, la db esta incluida en la carpeta data del proyecto Banco.Rest. 😉
