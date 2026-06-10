CREATE TABLE [sch_pedido].[Pedido]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_pedidos, 
    [IdCliente] INT NOT NULL, 
    [TotalBruto] DECIMAL(18, 2) NOT NULL, 
    [TotalNeto] DECIMAL(18, 2) NOT NULL, 
    [Adelanto] DECIMAL(18, 2) NOT NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT Getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Pedido_ToCliente] FOREIGN KEY (IdCliente) REFERENCES sch_pedido.[Cliente](Id)
)
