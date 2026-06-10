CREATE TABLE [sch_pedido].[PedidoDetalle]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_pedidos_detalle, 
    [IdPedido] INT NOT NULL, 
    [IdProducto] INT NOT NULL, 
    [Cantidad] DECIMAL(18, 2) NOT NULL, 
    [PrecioUnitario] DECIMAL(18, 2) NOT NULL, 
    [TotalBruto] DECIMAL(18, 2) NOT NULL, 
    [TotalNeto] DECIMAL(18, 2) NOT NULL,
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT Getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_PedidoDetalle_ToPedido] FOREIGN KEY (IdPedido) REFERENCES sch_pedido.pedido(Id), 
    CONSTRAINT [FK_PedidoDetalle_ToProducto] FOREIGN KEY (IdProducto) REFERENCES sch_pedido.producto(Id), 
)
