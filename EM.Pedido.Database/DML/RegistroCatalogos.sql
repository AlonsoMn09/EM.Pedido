/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


DECLARE  @IdCatalogoMarcas INT = 0;

INSERT INTO Sch_Configuracion.Catalogo (Codigo, Nombre, Descripcion)
VALUES ('MAE_MARCAS', 'MARCAS', 'CATALOGO DE MARCAS DE LOS PRODUCTOS')

SET @IdCatalogoMarcas = (SELECT @@IDENTITY)

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoMarcas, 'M_PRIMOR', 'PRIMOR'),
    (@IdCatalogoMarcas, 'M_GLORIA', 'GLORIA'),
    (@IdCatalogoMarcas, 'M_MOLITALIA', 'MOLITALIA'),
    (@IdCatalogoMarcas, 'M_CIELO', 'CIELO')


DECLARE @IdCatalogoCategorias INT = 0;

INSERT INTO Sch_Configuracion.Catalogo (Codigo, Nombre, Descripcion)
VALUES ('MAE_CATEGORIAS', 'CATEGORIAS', 'CATALOGO DE CATEGORIAS DE LOS PRODUCTOS')

SET @IdCatalogoCategorias = (SELECT @@IDENTITY)

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoCategorias, 'C_LIMPIEZA', 'LIMPIEZA'),
    (@IdCatalogoCategorias, 'C_ALIMENTOS', 'ALIMENTOS'),
    (@IdCatalogoCategorias, 'C_ASEO', 'ASEO PERSONAL'),
    (@IdCatalogoCategorias, 'C_BEBIDAS', 'GASEOSAS')


DECLARE @IdCatalogoRubros INT = 0;

INSERT INTO Sch_Configuracion.Catalogo (Codigo, Nombre, Descripcion)
VALUES ('MAE_RUBROS', 'RUBROS', 'CATALOGO DE RUBROS DE LOS CLIENTE')

SET @IdCatalogoRubros = (SELECT @@IDENTITY)

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoRubros, 'R_GIMNASIO', 'GIMNASIO'),
    (@IdCatalogoRubros, 'R_BODEGA', 'BODEGA'),
    (@IdCatalogoRubros, 'R_FARMACIA', 'FARMACIA'),
    (@IdCatalogoRubros, 'R_KIOSKO', 'KIOSKO')

DECLARE @ID_ESTADO_PEDIDO INT
INSERT INTO Sch_Configuracion.Catalogo (Codigo, Nombre, Descripcion, FechaCreacion, UsuarioCreacion)
VALUES ('MAE_ESTPDD','ESTADO PEDIDO','ESTADOS DEL PEDIDO', GETDATE(), 'Admin')

SET @ID_ESTADO_PEDIDO = (SELECT @@IDENTITY)

INSERT INTO Sch_Configuracion.CatalogoDetalle (Codigo, IdCatalogo, Valor, FechaCreacion, UsuarioCreacion)
VALUES
    ('PDD_REGISTRADO',@ID_ESTADO_PEDIDO,  'REGISTRADO', GETDATE() , 'Admin'),
    ('PDD_RECIBIDO',@ID_ESTADO_PEDIDO, 'RECIBIDO', GETDATE() , 'Admin'),
    ('PDD_DESPACHO',@ID_ESTADO_PEDIDO, 'EN DESPACHO', GETDATE() , 'Admin'),
    ('PDD_CAMINO',@ID_ESTADO_PEDIDO, 'EN CAMINO', GETDATE() , 'Admin'),
    ('PDD_ENTREGADO',@ID_ESTADO_PEDIDO, 'ENTREGADO', GETDATE() , 'Admin'),
    ('PDD_CANCELADO',@ID_ESTADO_PEDIDO, 'CANCELADO', GETDATE() , 'Admin'),
    ('PDD_RETRASADO',@ID_ESTADO_PEDIDO, 'RETRASADO', GETDATE() , 'Admin')