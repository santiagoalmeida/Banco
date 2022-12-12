# Banco
Prueba técnica
Instrucciones:

1. Abrir en visual studio 2022.
___
Arquitectura:

Servicio\
├─Banco.Core(Entities, interfaces, definitions)\
├─Banco.DataAccess(DbContext, ConfigurationEntities, Migrations, Repositories, UnitOfWork)\
├─Banco.Rest(ServicioRest)\
└─Banco.Services(BusinessLogic)
Cleinte\
└─Banco.Web(Aplicacion de cliente)
___

2. Crear la db con el script que se encuentra en la carpeta de Documento y cambiar la cadena de conección si es necesario. 😉

3. Click derecho solución>Propiedades y configurar multiples proyectos de inicio como en la imagen:
![image](https://user-images.githubusercontent.com/4412640/178529422-2ff492ea-b5de-4344-9e2e-2aedd915ab5f.png)

![image](https://user-images.githubusercontent.com/4412640/178537969-08ebe109-fb69-4cf6-a069-b31a10023ca7.png)
![image](https://user-images.githubusercontent.com/4412640/178538280-00d76208-6753-4189-be8b-0e931f67afe2.png)
![image](https://user-images.githubusercontent.com/4412640/178539146-4fd5ec8a-4b50-42e3-bb86-b78563994e1d.png)
![image](https://user-images.githubusercontent.com/4412640/178539181-b96c4202-7ea7-4942-8e1a-eef3ded34302.png)
![image](https://user-images.githubusercontent.com/4412640/178538577-02b19f3f-dc83-4cd7-8909-cb318a51c99b.png)
