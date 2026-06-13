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


DECLARE @IdCatalogoMarcas INT = NEXT VALUE FOR dbo.Seq_Catalogo;

INSERT INTO Sch_Configuracion.Catalogo (Id, Codigo, Nombre, Descripcion)
VALUES (@IdCatalogoMarcas, 'MAE_MARCAS', 'MARCAS', 'CATALOGO DE MARCAS DE LOS PRODUCTOS');

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoMarcas, 'M_PRIMOR', 'PRIMOR'),
    (@IdCatalogoMarcas, 'M_GLORIA', 'GLORIA'),
    (@IdCatalogoMarcas, 'M_MOLITALIA', 'MOLITALIA'),
    (@IdCatalogoMarcas, 'M_CIELO', 'CIELO');


DECLARE @IdCatalogoCategorias INT = NEXT VALUE FOR dbo.Seq_Catalogo;

INSERT INTO Sch_Configuracion.Catalogo (Id, Codigo, Nombre, Descripcion)
VALUES (@IdCatalogoCategorias, 'MAE_CATEGORIAS', 'CATEGORIAS', 'CATALOGO DE CATEGORIAS DE LOS PRODUCTOS');

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoCategorias, 'C_LIMPIEZA', 'LIMPIEZA'),
    (@IdCatalogoCategorias, 'C_ALIMENTOS', 'ALIMENTOS'),
    (@IdCatalogoCategorias, 'C_ASEO', 'ASEO PERSONAL'),
    (@IdCatalogoCategorias, 'C_BEBIDAS', 'GASEOSAS');


DECLARE @IdCatalogoRubros INT = NEXT VALUE FOR dbo.Seq_Catalogo;

INSERT INTO Sch_Configuracion.Catalogo (Id, Codigo, Nombre, Descripcion)
VALUES (@IdCatalogoRubros, 'MAE_RUBROS', 'RUBROS', 'CATALOGO DE RUBROS DE LOS CLIENTE');

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@IdCatalogoRubros, 'R_GIMNASIO', 'GIMNASIO'),
    (@IdCatalogoRubros, 'R_BODEGA', 'BODEGA'),
    (@IdCatalogoRubros, 'R_FARMACIA', 'FARMACIA'),
    (@IdCatalogoRubros, 'R_KIOSKO', 'KIOSKO');


DECLARE @ID_ESTADO_PEDIDO INT = NEXT VALUE FOR dbo.Seq_Catalogo;

INSERT INTO Sch_Configuracion.Catalogo (Id, Codigo, Nombre, Descripcion, FechaCreacion, UsuarioCreacion)
VALUES (@ID_ESTADO_PEDIDO, 'MAE_ESTPDD','ESTADO PEDIDO','ESTADOS DEL PEDIDO', GETDATE(), 'Admin');

INSERT INTO Sch_Configuracion.CatalogoDetalle (Codigo, IdCatalogo, Valor, FechaCreacion, UsuarioCreacion)
VALUES
    ('PDD_REGISTRADO',@ID_ESTADO_PEDIDO,  'REGISTRADO', GETDATE() , 'Admin'),
    ('PDD_RECIBIDO',@ID_ESTADO_PEDIDO, 'RECIBIDO', GETDATE() , 'Admin'),
    ('PDD_DESPACHO',@ID_ESTADO_PEDIDO, 'EN DESPACHO', GETDATE() , 'Admin'),
    ('PDD_CAMINO',@ID_ESTADO_PEDIDO, 'EN CAMINO', GETDATE() , 'Admin'),
    ('PDD_ENTREGADO',@ID_ESTADO_PEDIDO, 'ENTREGADO', GETDATE() , 'Admin'),
    ('PDD_CANCELADO',@ID_ESTADO_PEDIDO, 'CANCELADO', GETDATE() , 'Admin'),
    ('PDD_RETRASADO',@ID_ESTADO_PEDIDO, 'RETRASADO', GETDATE() , 'Admin');

DECLARE @ID_TIPO_DOC INT = NEXT VALUE FOR dbo.Seq_Catalogo;

INSERT INTO Sch_Configuracion.Catalogo (Id, Codigo, Nombre, Descripcion)
VALUES (@ID_TIPO_DOC, 'MAE_TIPO_DOC','TIPO DOCUMENTOS','CATALOGO DE TIPO DE DOCUMENTOS DE IDENTIDAD');

INSERT INTO Sch_Configuracion.CatalogoDetalle (IdCatalogo, Codigo, Valor)
VALUES
    (@ID_TIPO_DOC, 'TD_DNI', 'DNI'),
    (@ID_TIPO_DOC, 'TD_RUC', 'RUC'),
    (@ID_TIPO_DOC, 'TD_CEX', 'CE');
