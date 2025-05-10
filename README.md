Aplicación sencilla con una arquitectura entendible y escalable basada en la recomendada por Microsoft para aplicaciones basadas en .NET Core.

Explicación breve de las capas:
- Application -> lógica de negocio, cómo validaciones o funcionalidades específicas, también incluye la creación de los map's con AutoMapper
- DataAccess -> interación con la db, es decir consultas a través de los modelos
- Integrations -> llamadas a servicios externos, por ejemplo el servicio de login en Java
- WebApi -> controladores
Por cada capa hay dos secciones, la interfaz y su implementación, la inyección de dependencias se realiza por cada capa a través de "ServiceExtension", sin necesidad
de poner la inyección directamente en program.

Cualquier cosa que no entiendan pregunten a Chat GPT.
