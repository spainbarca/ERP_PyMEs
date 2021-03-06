USE [master]
GO
/****** Object:  Database [BD_I2_Bodega]    Script Date: 15/11/2020 10:46:54 ******/
CREATE DATABASE [BD_I2_Bodega]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_I2_Bodega', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BD_I2_Bodega.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD_I2_Bodega_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BD_I2_Bodega_log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BD_I2_Bodega] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_I2_Bodega].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_I2_Bodega] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_I2_Bodega] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_I2_Bodega] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_I2_Bodega] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_I2_Bodega] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_I2_Bodega] SET  MULTI_USER 
GO
ALTER DATABASE [BD_I2_Bodega] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_I2_Bodega] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_I2_Bodega] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_I2_Bodega] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BD_I2_Bodega] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BD_I2_Bodega]
GO
/****** Object:  Table [dbo].[t_almacen]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_almacen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[tipo] [varchar](50) NULL,
	[motivo] [varchar](max) NULL,
	[cantidad] [int] NULL,
	[producto] [int] NULL,
 CONSTRAINT [PK_t_almacen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_caja]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_caja](
	[id_caja] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[tema] [varchar](50) NULL,
	[serial_pc] [varchar](50) NULL,
	[impresora_ticket] [varchar](50) NULL,
	[impresora_a4] [varchar](50) NULL,
 CONSTRAINT [PK_t_caja] PRIMARY KEY CLUSTERED 
(
	[id_caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_categorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_categorias](
	[id_cat] [int] IDENTITY(1,1) NOT NULL,
	[cod_cat]  AS ('cat'+right('000'+CONVERT([varchar],[id_cat]),(3))),
	[nombre_cat] [varchar](50) NULL,
	[descripcion_cat] [varchar](max) NULL,
 CONSTRAINT [PK_t_categorias] PRIMARY KEY CLUSTERED 
(
	[id_cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_cierrecaja]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_cierrecaja](
	[id_cierrecaja] [int] IDENTITY(1,1) NOT NULL,
	[fecha_inicio] [datetime] NULL,
	[fecha_fin] [datetime] NULL,
	[fecha_cierre] [datetime] NULL,
	[ingresos] [numeric](18, 2) NULL,
	[egresos] [numeric](18, 2) NULL,
	[saldo] [numeric](18, 2) NULL,
	[id_usuario] [int] NULL,
	[total_calc]  AS (([ingresos]-[egresos])+[saldo]),
	[total_real] [numeric](18, 2) NULL,
	[estado] [varchar](50) NULL,
	[diferencia] [numeric](18, 2) NULL,
	[id_caja] [int] NULL,
 CONSTRAINT [PK_t_cierrecaja] PRIMARY KEY CLUSTERED 
(
	[id_cierrecaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_clientes]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_clientes](
	[id_cli] [int] IDENTITY(1,1) NOT NULL,
	[prinom_cli] [varchar](50) NULL,
	[segnom_cli] [varchar](50) NULL,
	[app_cli] [varchar](50) NULL,
	[apm_cli] [varchar](50) NULL,
	[fecha_cli] [date] NULL,
	[genero] [varchar](50) NULL,
	[tipo_cli] [int] NULL,
	[email] [varchar](max) NULL,
	[telefono] [varchar](50) NULL,
	[celular] [varchar](50) NULL,
	[direccion] [varchar](max) NULL,
	[dni] [varchar](50) NULL,
	[foto_cli] [image] NULL,
	[nombrefoto] [varchar](max) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_t_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_detallereporte]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_detallereporte](
	[id_rep] [int] IDENTITY(1,1) NOT NULL,
	[idprod_rep] [int] NULL,
	[cod_rep] [varchar](50) NULL,
	[prod_rep] [varchar](max) NULL,
	[costo_rep] [numeric](18, 2) NULL,
	[precio_rep] [numeric](18, 2) NULL,
	[stock_rep] [int] NULL,
	[minimo_rep] [int] NULL,
	[total_rep] [numeric](18, 2) NULL,
 CONSTRAINT [PK_t_detallereporte] PRIMARY KEY CLUSTERED 
(
	[id_rep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_detalleventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_detalleventa](
	[id_venta] [int] NOT NULL,
	[id_detalleventa] [int] NOT NULL,
	[producto] [int] NULL,
	[cantidad] [int] NULL,
	[precio_unit] [numeric](18, 2) NULL,
	[moneda] [varchar](50) NULL,
	[total_pagar]  AS ([precio_unit]*[cantidad]),
	[unidad_medida] [varchar](50) NULL,
	[cant_mostrada] [int] NULL,
	[estado] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
	[codigo] [varchar](50) NULL,
	[stock] [int] NULL,
	[unidades] [varchar](50) NULL,
	[usa_inventario] [varchar](50) NULL,
	[costo] [numeric](18, 2) NULL,
	[ganancia]  AS ([precio_unit]*[cantidad]-[costo]*[cantidad]),
 CONSTRAINT [PK_t_detalleventa] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC,
	[id_detalleventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_entradapeli]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_entradapeli](
	[id_ent] [int] IDENTITY(1,1) NOT NULL,
	[id_peli] [int] NULL,
	[cantidad] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_fabricas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_fabricas](
	[id_fab] [int] IDENTITY(1,1) NOT NULL,
	[cod_fab]  AS ('fab'+right('000'+CONVERT([varchar],[id_fab]),(3))),
	[nombre_fab] [varchar](50) NULL,
	[descripcion_fab] [varchar](max) NULL,
	[logo_fab] [image] NULL,
	[nombrelogo_fab] [varchar](max) NULL,
 CONSTRAINT [PK_t_fabricas] PRIMARY KEY CLUSTERED 
(
	[id_fab] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_fichas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_fichas](
	[id_ficha] [int] IDENTITY(1,1) NOT NULL,
	[juego] [int] NULL,
	[cantidad_ficha] [int] NULL,
	[precio_ficha] [numeric](18, 2) NULL,
 CONSTRAINT [PK_t_fichas] PRIMARY KEY CLUSTERED 
(
	[id_ficha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_iniciosesion]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_iniciosesion](
	[id_iniciosesion] [int] IDENTITY(1,1) NOT NULL,
	[serial_pc] [varchar](50) NULL,
	[id_usuario] [int] NULL,
	[fecha] [timestamp] NULL,
 CONSTRAINT [PK_t_iniciosesion] PRIMARY KEY CLUSTERED 
(
	[id_iniciosesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_juegos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_juegos](
	[id_juego] [int] IDENTITY(1,1) NOT NULL,
	[nom_juego] [varchar](50) NULL,
	[cantidad] [int] NULL,
	[precio_juego] [numeric](18, 2) NULL,
 CONSTRAINT [PK_t_juegos] PRIMARY KEY CLUSTERED 
(
	[id_juego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_kardex]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_kardex](
	[id_kardex] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[motivo] [varchar](50) NULL,
	[cantidad] [int] NULL,
	[producto] [int] NULL,
	[usuario] [int] NULL,
	[tipo] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[total]  AS ([cantidad]*[costo_unit]),
	[costo_unit] [numeric](18, 2) NULL,
	[habia] [int] NULL,
	[hay] [int] NULL,
	[id_caja] [int] NULL,
 CONSTRAINT [PK_t_kardex] PRIMARY KEY CLUSTERED 
(
	[id_kardex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_marcas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_marcas](
	[id_mar] [int] IDENTITY(1,1) NOT NULL,
	[cod_mar]  AS ('mar'+right('000'+CONVERT([varchar],[id_mar]),(3))),
	[nombre_mar] [varchar](50) NULL,
	[id_fab] [int] NULL,
	[logo_mar] [image] NULL,
	[nombrelogo_mar] [varchar](max) NULL,
 CONSTRAINT [PK_t_marcas] PRIMARY KEY CLUSTERED 
(
	[id_mar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_peli]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_peli](
	[id_peli] [int] IDENTITY(1,1) NOT NULL,
	[nom_peli] [varchar](50) NULL,
	[precio_peli] [numeric](18, 2) NULL,
	[stock] [int] NULL,
 CONSTRAINT [PK_t_peli] PRIMARY KEY CLUSTERED 
(
	[id_peli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_productos](
	[id_prod] [int] IDENTITY(1,1) NOT NULL,
	[cod_prod]  AS ('prod'+right('0000'+CONVERT([varchar],[id_prod]),(4))),
	[nombre_prod] [varchar](max) NULL,
	[imagen_prod] [image] NULL,
	[nombreimagen] [varchar](max) NULL,
	[id_categoria] [int] NULL,
	[id_subcategoria] [int] NULL,
	[id_marca] [int] NULL,
	[usa_inventario] [varchar](2) NULL,
	[stock] [int] NULL,
	[precio_compra] [numeric](18, 2) NULL,
	[precio_venta] [numeric](18, 2) NULL,
	[fecha_venc] [varchar](50) NULL,
	[codigo] [varchar](50) NULL,
	[precio_mayor] [numeric](18, 2) NULL,
	[cant_mayor] [int] NULL,
	[impuesto] [numeric](18, 2) NULL,
	[stock_min] [int] NULL,
	[subtotal_pv]  AS ([precio_venta]*[stock]),
	[subtotal_pm]  AS ([precio_mayor]*[cant_mayor]),
	[tipo_prod] [varchar](50) NULL,
 CONSTRAINT [PK_t_productos] PRIMARY KEY CLUSTERED 
(
	[id_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_rol]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_t_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_subcategorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_subcategorias](
	[id_subcat] [int] IDENTITY(1,1) NOT NULL,
	[cod_subcat]  AS ('sub'+right('000'+CONVERT([varchar],[id_subcat]),(3))),
	[id_cat] [int] NULL,
	[nombre_subcat] [varchar](50) NULL,
	[descripcion_subcat] [varchar](max) NULL,
 CONSTRAINT [PK_t_subcategorias] PRIMARY KEY CLUSTERED 
(
	[id_subcat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_tipocliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_tipocliente](
	[id_tipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_t_tipocliente] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_usuarios]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_usuarios](
	[id_usu] [int] IDENTITY(1,1) NOT NULL,
	[prinom_usu] [varchar](50) NULL,
	[segnom_usu] [varchar](50) NULL,
	[app_usu] [varchar](50) NULL,
	[apm_usu] [varchar](50) NULL,
	[fecha_nac] [date] NULL,
	[genero] [varchar](50) NULL,
	[rol_usu] [int] NULL,
	[correo] [varchar](max) NULL,
	[icono] [image] NULL,
	[nom_icono] [varchar](max) NULL,
	[usuario] [varchar](50) NULL,
	[clave] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_t_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_ventas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [int] NULL,
	[fecha_venta] [datetime] NULL,
	[num_doc] [varchar](50) NULL,
	[monto_total] [numeric](18, 2) NULL,
	[tipo_pago] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[igv]  AS ([monto_total]*[porc_igv]),
	[boleta] [varchar](50) NULL,
	[usuario] [int] NULL,
	[fecha_pago] [datetime] NULL,
	[accion] [varchar](50) NULL,
	[saldo]  AS ([monto_total]-[pago_parcial]),
	[pago_parcial] [numeric](18, 2) NULL,
	[porc_igv] [numeric](18, 2) NULL,
	[caja] [int] NULL,
	[referencia_card] [int] NULL,
	[vuelto]  AS ([efectivo]-[monto_total]),
	[efectivo] [numeric](18, 2) NULL,
	[credito] [varchar](50) NULL,
	[tarjeta] [varchar](50) NULL,
 CONSTRAINT [PK_t_ventas] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[t_cierrecaja]  WITH CHECK ADD  CONSTRAINT [FK_t_cierrecaja_t_caja] FOREIGN KEY([id_caja])
REFERENCES [dbo].[t_caja] ([id_caja])
GO
ALTER TABLE [dbo].[t_cierrecaja] CHECK CONSTRAINT [FK_t_cierrecaja_t_caja]
GO
ALTER TABLE [dbo].[t_clientes]  WITH CHECK ADD  CONSTRAINT [FK_t_clientes_t_tipocliente] FOREIGN KEY([tipo_cli])
REFERENCES [dbo].[t_tipocliente] ([id_tipo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_clientes] CHECK CONSTRAINT [FK_t_clientes_t_tipocliente]
GO
ALTER TABLE [dbo].[t_detalleventa]  WITH CHECK ADD  CONSTRAINT [FK_t_detalleventa_t_productos] FOREIGN KEY([producto])
REFERENCES [dbo].[t_productos] ([id_prod])
GO
ALTER TABLE [dbo].[t_detalleventa] CHECK CONSTRAINT [FK_t_detalleventa_t_productos]
GO
ALTER TABLE [dbo].[t_detalleventa]  WITH CHECK ADD  CONSTRAINT [FK_t_detalleventa_t_ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[t_ventas] ([id_venta])
GO
ALTER TABLE [dbo].[t_detalleventa] CHECK CONSTRAINT [FK_t_detalleventa_t_ventas]
GO
ALTER TABLE [dbo].[t_fichas]  WITH CHECK ADD  CONSTRAINT [FK_t_fichas_t_juegos] FOREIGN KEY([juego])
REFERENCES [dbo].[t_juegos] ([id_juego])
GO
ALTER TABLE [dbo].[t_fichas] CHECK CONSTRAINT [FK_t_fichas_t_juegos]
GO
ALTER TABLE [dbo].[t_iniciosesion]  WITH CHECK ADD  CONSTRAINT [FK_t_iniciosesion_t_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[t_usuarios] ([id_usu])
GO
ALTER TABLE [dbo].[t_iniciosesion] CHECK CONSTRAINT [FK_t_iniciosesion_t_usuarios]
GO
ALTER TABLE [dbo].[t_kardex]  WITH CHECK ADD  CONSTRAINT [FK_t_kardex_t_caja] FOREIGN KEY([id_caja])
REFERENCES [dbo].[t_caja] ([id_caja])
GO
ALTER TABLE [dbo].[t_kardex] CHECK CONSTRAINT [FK_t_kardex_t_caja]
GO
ALTER TABLE [dbo].[t_kardex]  WITH CHECK ADD  CONSTRAINT [FK_t_kardex_t_productos] FOREIGN KEY([producto])
REFERENCES [dbo].[t_productos] ([id_prod])
GO
ALTER TABLE [dbo].[t_kardex] CHECK CONSTRAINT [FK_t_kardex_t_productos]
GO
ALTER TABLE [dbo].[t_kardex]  WITH CHECK ADD  CONSTRAINT [FK_t_kardex_t_usuarios] FOREIGN KEY([usuario])
REFERENCES [dbo].[t_usuarios] ([id_usu])
GO
ALTER TABLE [dbo].[t_kardex] CHECK CONSTRAINT [FK_t_kardex_t_usuarios]
GO
ALTER TABLE [dbo].[t_marcas]  WITH CHECK ADD  CONSTRAINT [FK_t_marcas_t_fabricas] FOREIGN KEY([id_fab])
REFERENCES [dbo].[t_fabricas] ([id_fab])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_marcas] CHECK CONSTRAINT [FK_t_marcas_t_fabricas]
GO
ALTER TABLE [dbo].[t_productos]  WITH CHECK ADD  CONSTRAINT [FK_t_productos_t_marcas] FOREIGN KEY([id_marca])
REFERENCES [dbo].[t_marcas] ([id_mar])
GO
ALTER TABLE [dbo].[t_productos] CHECK CONSTRAINT [FK_t_productos_t_marcas]
GO
ALTER TABLE [dbo].[t_productos]  WITH CHECK ADD  CONSTRAINT [FK_t_productos_t_subcategorias] FOREIGN KEY([id_subcategoria])
REFERENCES [dbo].[t_subcategorias] ([id_subcat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_productos] CHECK CONSTRAINT [FK_t_productos_t_subcategorias]
GO
ALTER TABLE [dbo].[t_subcategorias]  WITH CHECK ADD  CONSTRAINT [FK_t_subcategorias_t_categorias] FOREIGN KEY([id_cat])
REFERENCES [dbo].[t_categorias] ([id_cat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_subcategorias] CHECK CONSTRAINT [FK_t_subcategorias_t_categorias]
GO
ALTER TABLE [dbo].[t_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_t_usuarios_t_rol] FOREIGN KEY([rol_usu])
REFERENCES [dbo].[t_rol] ([id_rol])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_usuarios] CHECK CONSTRAINT [FK_t_usuarios_t_rol]
GO
ALTER TABLE [dbo].[t_ventas]  WITH CHECK ADD  CONSTRAINT [FK_t_ventas_t_caja] FOREIGN KEY([caja])
REFERENCES [dbo].[t_caja] ([id_caja])
GO
ALTER TABLE [dbo].[t_ventas] CHECK CONSTRAINT [FK_t_ventas_t_caja]
GO
ALTER TABLE [dbo].[t_ventas]  WITH CHECK ADD  CONSTRAINT [FK_t_ventas_t_clientes] FOREIGN KEY([cliente])
REFERENCES [dbo].[t_clientes] ([id_cli])
GO
ALTER TABLE [dbo].[t_ventas] CHECK CONSTRAINT [FK_t_ventas_t_clientes]
GO
ALTER TABLE [dbo].[t_ventas]  WITH CHECK ADD  CONSTRAINT [FK_t_ventas_t_usuarios] FOREIGN KEY([usuario])
REFERENCES [dbo].[t_usuarios] ([id_usu])
GO
ALTER TABLE [dbo].[t_ventas] CHECK CONSTRAINT [FK_t_ventas_t_usuarios]
GO
/****** Object:  StoredProcedure [dbo].[actualizar_productorepetido]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[actualizar_productorepetido]

@id_venta		int,
@producto		int

AS

UPDATE t_detalleventa 
SET cantidad=cantidad+1, cant_mostrada=cant_mostrada+1
WHERE id_venta=@id_venta AND producto=@producto
GO
/****** Object:  StoredProcedure [dbo].[actualizar_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[actualizar_usuario]
@id_usu			int,
@prinom_usu		varchar(50),
@segnom_usu		varchar(50),
@app_usu		varchar(50),
@apm_usu		varchar(50),
@fecha_nac		date,
@genero			varchar(50),
@rol_usu		int,
@correo			varchar(max),
@icono			image,
@nom_icono		varchar(max),
@usuario		varchar(50),
@clave			varchar(50),
@estado			varchar(50)

as

if exists(SELECT usuario from t_usuarios WHERE @usuario=usuario AND estado='ACTIVADO')
RAISERROR('YA EXISTE UN USUARIO CON ESTE REGISTRO, POR FAVOR, INGRESE OTRO VALOR', 16, 1) 
ELSE

UPDATE t_usuarios set 
prinom_usu=@prinom_usu,
segnom_usu=@segnom_usu,
app_usu=@app_usu,
apm_usu=@apm_usu,
fecha_nac=@fecha_nac,
genero=@genero,
rol_usu=@rol_usu,
correo=@correo,
icono=@icono,
nom_icono=@nom_icono,
usuario=@usuario,
clave=@clave,
estado=@estado

WHERE id_usu=@id_usu;
GO
/****** Object:  StoredProcedure [dbo].[apertura_cajainicial]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[apertura_cajainicial]

@fecha_inicio		datetime,
@fecha_fin			datetime,
@fecha_cierre		datetime,
@ingresos			numeric(18,2),
@egresos			numeric(18,2),
@saldo				numeric(18,2),
@id_usuario			int,
@total_real			numeric(18,2),
@estado				varchar(50),
@diferencia			numeric(18,2),
@id_caja			int

AS

if exists(SELECT estado from t_cierrecaja where estado='CAJA APERTURADA')
raiserror('ESTA CAJA YA ESTA APERTURADA!!',16,1)

ELSE


INSERT INTO t_cierrecaja VALUES
(@fecha_inicio,
@fecha_fin,
@fecha_cierre,
@ingresos,
@egresos,
@saldo,
@id_usuario,
@total_real,
@estado,
@diferencia,
@id_caja
)
GO
/****** Object:  StoredProcedure [dbo].[aperturar_venta]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[aperturar_venta]
@monto_total	numeric(18,2),
@estado			varchar(50)

AS

INSERT INTO t_ventas(monto_total,estado) 
VALUES (@monto_total,@estado)

GO
/****** Object:  StoredProcedure [dbo].[autobusqueda_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[autobusqueda_productos]
@multi	varchar(50)

AS

select TOP 5 id_prod, codigo AS Código, nombre_prod AS Producto, precio_compra AS Costo, precio_venta AS 'Precio Venta', stock AS Stock, stock_min AS Mínimo,
t_categorias.nombre_cat AS Categoría, t_subcategorias.nombre_subcat AS Subcategoría, t_marcas.nombre_mar AS Marca,
subtotal_pv AS Importe
FROM t_productos
INNER JOIN t_categorias ON t_productos.id_categoria=t_categorias.id_cat
INNER JOIN t_subcategorias	ON t_productos.id_subcategoria = t_subcategorias.id_subcat
INNER JOIN t_marcas	ON t_productos.id_marca = t_marcas.id_mar

WHERE cod_prod + nombre_prod LIKE '%' + @multi + '%'
GO
/****** Object:  StoredProcedure [dbo].[autobusqueda_ventas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[autobusqueda_ventas]

@multi	varchar(50)

AS

select TOP 5 id_prod, codigo AS Código, nombre_prod AS Producto, precio_compra AS Costo, precio_venta AS 'Precio Venta', 
stock AS Stock, stock_min AS Mínimo,
t_categorias.nombre_cat AS Categoría, t_subcategorias.nombre_subcat AS Subcategoría, t_marcas.nombre_mar AS Marca,
subtotal_pv AS Importe, tipo_prod, usa_inventario, CONCAT(nombre_prod,' ',nombre_cat,' ', nombre_subcat,' ', nombre_mar) AS Descripcion
FROM t_productos
INNER JOIN t_categorias ON t_productos.id_categoria=t_categorias.id_cat
INNER JOIN t_subcategorias	ON t_productos.id_subcategoria = t_subcategorias.id_subcat
INNER JOIN t_marcas	ON t_productos.id_marca = t_marcas.id_mar

WHERE nombre_prod  LIKE '%' + @multi + '%'
GO
/****** Object:  StoredProcedure [dbo].[boton_mas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[boton_mas]

@id_venta		int,
@producto		int

AS

if exists (SELECT cantidad,stock  from t_detalleventa WHERE id_venta=@id_venta AND producto=@producto and cantidad<stock)

UPDATE t_detalleventa 
SET cantidad=cantidad+1, cant_mostrada=cant_mostrada+1
WHERE id_venta=@id_venta AND producto=@producto and cantidad<stock

ELSE

raiserror('LA CANTIDAD SUPERÓ EL STOCK LIMITE',16,1)
GO
/****** Object:  StoredProcedure [dbo].[boton_menos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[boton_menos]

@id_venta		int,
@producto		int

AS

if exists (SELECT cantidad,stock  from t_detalleventa WHERE id_venta=@id_venta AND producto=@producto and cantidad>1)

UPDATE t_detalleventa 
SET cantidad=cantidad-1, cant_mostrada=cant_mostrada-1
WHERE id_venta=@id_venta AND producto=@producto and cantidad>1

ELSE

BEGIN

raiserror('PRODUCTO ELIMINADO',16,1)

DELETE FROM t_detalleventa

WHERE id_venta=@id_venta AND producto=@producto 

END
GO
/****** Object:  StoredProcedure [dbo].[buscar_categorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_categorias]

@multi	varchar(50)

AS

select id_cat as 'ID', cod_cat as 'Código', nombre_cat as 'Categorías', descripcion_cat as 'Descripción' 
from t_categorias
WHERE nombre_cat + descripcion_cat LIKE '%' + @multi +'%'

GO
/****** Object:  StoredProcedure [dbo].[buscar_clientes]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_clientes]

@multi	varchar(50)

AS

SELECT id_cli, CONCAT(prinom_cli,' ',segnom_cli,' ', app_cli,' ', apm_cli) AS Cliente, prinom_cli, segnom_cli, app_cli, apm_cli, fecha_cli, genero,
t_tipocliente.nombre_tipo AS 'Tipo', email, telefono, celular, direccion, dni, foto_cli, nombrefoto, estado
FROM t_clientes
INNER JOIN t_tipocliente ON t_clientes.tipo_cli=t_tipocliente.id_tipo

WHERE prinom_cli+segnom_cli+app_cli+apm_cli+t_tipocliente.nombre_tipo + email+dni LIKE  '%'+ @multi+ '%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_fabricas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_fabricas]

@multi	varchar(50)

AS

SELECT id_fab AS 'ID', cod_fab AS 'Código', nombre_fab AS 'Fábrica', descripcion_fab AS 'Descripción', logo_fab, nombrelogo_fab 
FROM t_fabricas
WHERE nombre_fab + descripcion_fab LIKE '%' + @multi +'%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_kardex]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_kardex]

@multi	varchar(50)

AS
SELECT TOP 5 id_prod, nombre_prod AS Producto
FROM t_productos
WHERE t_productos.nombre_prod LIKE '%' + @multi + '%' and usa_inventario='SI'
GO
/****** Object:  StoredProcedure [dbo].[buscar_marcas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_marcas]

@multi	varchar(50)

AS

select id_mar AS 'ID', cod_mar AS 'Código', nombre_mar AS 'Marcas', t_fabricas.nombre_fab AS 'Fábrica', logo_mar, nombrelogo_mar
from t_marcas
--innerjoin $tablaajena ON comunA=comunB
inner join t_fabricas on t_marcas.id_fab = t_fabricas.id_fab
WHERE nombre_mar + nombre_fab LIKE '%' + @multi +'%'

GO
/****** Object:  StoredProcedure [dbo].[buscar_movimientos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_movimientos] 

@multi		varchar(50)

AS

SELECT id_kardex, t_kardex.fecha AS Fecha, t_productos.nombre_prod AS Producto, 
motivo AS Detalle, habia AS Había, tipo AS Tipo, cantidad AS Stock, hay AS Hay, t_usuarios.usuario AS Encargado,
t_categorias.nombre_cat AS Categoría, t_subcategorias.nombre_subcat AS Subcategoría

FROM t_kardex

INNER JOIN t_productos ON t_kardex.producto = t_productos.id_prod
INNER JOIN t_usuarios ON t_kardex.usuario = t_usuarios.id_usu
INNER JOIN t_subcategorias ON t_subcategorias.id_subcat=t_productos.id_subcategoria
INNER JOIN t_categorias ON t_categorias.id_cat = t_productos.id_categoria

WHERE t_productos.nombre_prod + t_categorias.nombre_cat + t_subcategorias.nombre_subcat 
LIKE '%' + @multi + '%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_productos]

@multi		varchar(50)

AS
SELECT id_prod AS 'ID', nombre_prod AS 'Producto', imagen_prod, nombreimagen, 
id_categoria, t_categorias.nombre_cat AS 'Categoría', id_subcategoria, t_subcategorias.nombre_subcat AS 'Subcategoría', id_marca, t_marcas.nombre_mar AS 'Marca',
usa_inventario, stock AS 'Stock', precio_compra, precio_venta AS 'Precio Venta', fecha_venc, codigo AS 'Código', precio_mayor AS 'Precio x Mayor', cant_mayor AS 'A partir de', 
impuesto, stock_min, tipo_prod
from t_productos
INNER JOIN t_categorias ON t_productos.id_categoria=t_categorias.id_cat
INNER JOIN t_subcategorias ON t_productos.id_subcategoria=t_subcategorias.id_subcat
INNER JOIN t_marcas ON t_productos.id_marca=t_marcas.id_mar

WHERE nombre_prod + t_categorias.nombre_cat + t_subcategorias.nombre_subcat + t_marcas.nombre_mar + codigo LIKE '%' + @multi + '%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_productos_vencidos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_productos_vencidos]

@multi		varchar(50)

AS
SELECT id_prod, codigo AS Código, nombre_prod AS Producto, fecha_venc AS FechaVencimiento, stock AS Stock,
DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) AS 'Días'
FROM t_productos where fecha_venc<>'NO APLICA' AND 
nombre_prod LIKE '%' + @multi + '%'  
GO
/****** Object:  StoredProcedure [dbo].[buscar_subcategorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_subcategorias]

@multi	varchar(50)

AS

select id_subcat AS 'ID', cod_subcat AS 'Código', t_categorias.nombre_cat AS 'Categoría', nombre_subcat AS 'Subcategoría', descripcion_subcat AS 'Descripción' 
from t_subcategorias
inner join t_categorias on t_subcategorias.id_cat = t_categorias.id_cat
WHERE nombre_cat + nombre_subcat + descripcion_subcat LIKE '%' + @multi +'%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_usuarios]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_usuarios]
@multi varchar(50)
AS

SELECT id_usu, prinom_usu as PrimerNombre, segnom_usu as SegundoNombre, app_usu as ApellidoPaterno, apm_usu as ApellidoMaterno, fecha_nac as FechaNacimiento, usuario as Usuario, genero, rol_usu, correo, icono, nom_icono, clave, estado
FROM t_usuarios
WHERE prinom_usu + segnom_usu + app_usu + apm_usu + usuario + genero LIKE '%' + @multi + '%' AND estado='ACTIVADO'
GO
/****** Object:  StoredProcedure [dbo].[cerrar_caja]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cerrar_caja]

@fecha_fin		datetime,
@fecha_cierre	datetime,
@ingresos		numeric(18,2),
@egresos		numeric(18,2),
@id_usuario		int,
@total_real		numeric(18,2),
@diferencia		numeric(18,2),
@id_caja		int

AS

UPDATE t_cierrecaja SET

fecha_fin=@fecha_fin,
fecha_cierre=@fecha_cierre,
ingresos=@ingresos,
egresos=@egresos,
id_usuario=@id_usuario,
total_real=@total_real,
diferencia=@diferencia,
estado = 'CAJA CERRADA'

WHERE id_caja=@id_caja and estado='CAJA APERTURADA'
GO
/****** Object:  StoredProcedure [dbo].[contar_clientes]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[contar_clientes]
@condicion		int

AS

if(@condicion='1')

BEGIN
SELECT COUNT(id_cli) AS Activos FROM t_clientes
WHERE estado='ACTIVADO'
END

ELSE

SELECT COUNT(id_cli) AS Eliminados FROM t_clientes
WHERE estado='ELIMINADO'
GO
/****** Object:  StoredProcedure [dbo].[contar_inventario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[contar_inventario]
AS
SELECT COUNT(id_kardex) AS TotalProductos FROM t_kardex;
GO
/****** Object:  StoredProcedure [dbo].[contar_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[contar_productos]
AS
SELECT COUNT(id_prod) AS TotalProductos FROM t_productos;
GO
/****** Object:  StoredProcedure [dbo].[crear_categoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_categoria]

@nombre_cat			varchar(50),
@descripcion_cat	varchar(MAX)

AS

INSERT INTO t_categorias VALUES
(@nombre_cat,
@descripcion_cat)

GO
/****** Object:  StoredProcedure [dbo].[crear_cliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_cliente]
@prinom_cli		varchar(50),
@segnom_cli		varchar(50),
@app_cli		varchar(50),
@apm_cli		varchar(50),
@fecha_cli		date,
@genero			varchar(50),
@tipo_cli		int,
@email			varchar(MAX),
@telefono		varchar(50),
@celular		varchar(50),
@direccion		varchar(MAX),
@dni			varchar(50),
@foto_cli		image,
@nombrefoto		varchar(MAX),
@estado			varchar(50)

AS

if exists (select email from t_clientes where email=@email)
raiserror('YA EXISTE UN CLIENTE CON ESE DATO, PORFAVOR INGRESE DE NUEVO',16,1)
ELSE

INSERT INTO t_clientes VALUES
(@prinom_cli,
@segnom_cli,
@app_cli,
@apm_cli,
@fecha_cli,
@genero	,
@tipo_cli,
@email,
@telefono,
@celular,
@direccion,
@dni,
@foto_cli,
@nombrefoto,
@estado)
GO
/****** Object:  StoredProcedure [dbo].[crear_fabrica]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[crear_fabrica]

@nombre_fab			varchar(50),
@descripcion_fab	varchar(MAX),
@logo_fab			image,
@nombrelogo_fab		varchar(MAX)

AS

INSERT INTO t_fabricas VALUES
(@nombre_fab,
@descripcion_fab,
@logo_fab,
@nombrelogo_fab)
GO
/****** Object:  StoredProcedure [dbo].[crear_marca]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_marca]
@nombre_mar			varchar(50),
@id_fab				int,
@logo_mar			image,
@nombrelogo_mar		varchar(MAX)

AS

INSERT INTO t_marcas VALUES
(@nombre_mar,
@id_fab,
@logo_mar,
@nombrelogo_mar)
GO
/****** Object:  StoredProcedure [dbo].[crear_producto]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_producto]

@nombre_prod		varchar(50),
@imagen_prod		image,
@nombre_imagen		varchar(MAX),
@id_categoria		int,
@id_subcategoria	int,
@id_marca			int,
@usa_inventario		varchar(2),
@stock				int,
@precio_compra		numeric(18,2),
@precio_venta		numeric(18,2),
@fecha_venc			date,
@codigo				varchar(50),
@precio_mayor		numeric(18,2),
@cant_mayor			int,
@impuesto			numeric(18,2),
@stock_min			int,
@tipo_prod			varchar(50),

--Ahora creamos los parametros para insertar en tabla kardex
@fecha				datetime,
@motivo				varchar(50),
@cantidad			int,
@usuario			int,
@tipo				varchar(50),
@estado				varchar(50),
@id_caja			int

AS

BEGIN
--Validamos que no se ingresen productos con el mismo nombre y codigo
if exists(SELECT @nombre_prod, @codigo from t_productos 
WHERE nombre_prod=@nombre_prod or codigo=@codigo)
RAISERROR ('El producto y/o el código ya existen en la base de datos, revise bien',16,1)

ELSE

BEGIN

DECLARE @producto  int --Capturo el id del producto que voy a ingresar para mandar ese mismo a kardex

INSERT INTO t_productos VALUES
(@nombre_prod,
@imagen_prod,
@nombre_imagen,
@id_categoria,
@id_subcategoria,
@id_marca,
@usa_inventario,
@stock,
@precio_compra,
@precio_venta,
@fecha_venc,
@codigo	,
@precio_mayor,
@cant_mayor,
@impuesto,
@stock_min,
@tipo_prod)

--Ahora seleccionemos el ID del producto
SELECT @producto = SCOPE_IDENTITY()
--Obtenemos los datos de este id

DECLARE @hay	as int
DECLARE @habia	as int
DECLARE @costo_unit as numeric(18,2)

SET @hay = (SELECT stock from t_productos WHERE id_prod=@producto and usa_inventario='SI')
SET @costo_unit = (SELECT precio_compra from t_productos WHERE id_prod=@producto)
SET @habia = 0

--Ahora comprobaremos si ese producto digitado usa inventario o no
SET @usa_inventario = (SELECT usa_inventario from t_productos WHERE id_prod=@producto and usa_inventario='SI')

if @usa_inventario='SI'

BEGIN

INSERT INTO t_kardex VALUES
(@fecha,
@motivo,
@cantidad,
@producto,
@usuario,
@tipo,
@estado,
@costo_unit,
@habia,
@hay,
@id_caja
)
END
END
END

GO
/****** Object:  StoredProcedure [dbo].[crear_subcategoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_subcategoria]

@id_cat					int,
@nombre_subcat			varchar(50),
@descripcion_subcat		varchar(MAX)

AS

INSERT INTO t_subcategorias VALUES
(@id_cat,
@nombre_subcat,
@descripcion_subcat)

GO
/****** Object:  StoredProcedure [dbo].[crear_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_usuario]
@prinom_usu		varchar(50),
@segnom_usu		varchar(50),
@app_usu		varchar(50),
@apm_usu		varchar(50),
@fecha_nac		date,
@genero			varchar(50),
@rol_usu		int,
@correo			varchar(max),
@icono			image,
@nom_icono		varchar(max),
@usuario		varchar(50),
@clave			varchar(50),
@estado			varchar(50)

as

if exists(SELECT usuario from t_usuarios WHERE @usuario=usuario AND estado='ACTIVADO')
RAISERROR('YA EXISTE UN USUARIO CON ESTE REGISTRO, POR FAVOR, INGRESE OTRO VALOR', 16, 1) 
ELSE

insert into t_usuarios 
values(@prinom_usu, 
@segnom_usu,
@app_usu,
@apm_usu,
@fecha_nac,
@genero,
@rol_usu,
@correo,
@icono,
@nom_icono,
@usuario,
@clave,
@estado)
GO
/****** Object:  StoredProcedure [dbo].[crear_venta]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_venta]
@monto_total	numeric(18,2)

AS

INSERT INTO t_ventas(monto_total) VALUES (@monto_total)
GO
/****** Object:  StoredProcedure [dbo].[editar_categoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_categoria]

@nombre_cat			varchar(50),
@descripcion_cat	varchar(MAX),
@id_cat				int

AS

update t_categorias set
nombre_cat=@nombre_cat,
descripcion_cat=@descripcion_cat

where id_cat=@id_cat

GO
/****** Object:  StoredProcedure [dbo].[editar_cliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_cliente]

@prinom_cli		varchar(50),
@segnom_cli		varchar(50),
@app_cli		varchar(50),
@apm_cli		varchar(50),
@fecha_cli		date,
@genero			varchar(50),
@tipo_cli		int,
@email			varchar(MAX),
@telefono		varchar(50),
@celular		varchar(50),
@direccion		varchar(MAX),
@dni			varchar(50),
@foto_cli		image,
@nombrefoto		varchar(MAX),
@id_cli			int

AS

if exists (SELECT email,id_cli  from t_clientes where (email=@email and id_cli<>@id_cli))
raiserror('YA EXISTE UN CLIENTE CON ESE CORREO, PORFAVOR EDITE DE NUEVO',16,1)
ELSE

UPDATE t_clientes SET

prinom_cli=@prinom_cli,
segnom_cli=@segnom_cli,
app_cli=@app_cli,
apm_cli=@apm_cli,
fecha_cli=@fecha_cli,
genero=@genero	,
tipo_cli=@tipo_cli,
email=@email,
telefono=@telefono,
celular=@celular,
direccion=@direccion,
dni=@dni,
foto_cli=@foto_cli,
nombrefoto=@nombrefoto

WHERE id_cli = @id_cli
GO
/****** Object:  StoredProcedure [dbo].[editar_fabrica]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_fabrica]

@id_fab				int,
@nombre_fab			varchar(50),
@descripcion_fab	varchar(MAX),
@logo_fab			image,
@nombrelogo_fab		varchar(MAX)

AS

UPDATE t_fabricas SET
nombre_fab = @nombre_fab,
descripcion_fab = @descripcion_fab,
logo_fab = @logo_fab,
nombrelogo_fab = @nombrelogo_fab

WHERE id_fab = @id_fab
GO
/****** Object:  StoredProcedure [dbo].[editar_marca]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_marca]

@id_mar				int,
@nombre_mar			varchar(50),
@id_fab				int,
@logo_mar			image,
@nombrelogo_mar		varchar(MAX)

AS

UPDATE t_marcas SET
nombre_mar = @nombre_mar,
id_fab = @id_fab,
logo_mar = @logo_mar,
nombrelogo_mar = @nombrelogo_mar

WHERE id_mar = @id_mar
GO
/****** Object:  StoredProcedure [dbo].[editar_producto]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_producto]

@id_prod			int,
@nombre_prod		varchar(50),
@imagen_prod		image,
@nombre_imagen		varchar(MAX),
@id_categoria		int,
@id_subcategoria	int,
@id_marca			int,
@precio_compra		numeric(18,2),
@precio_venta		numeric(18,2),
@codigo				varchar(50),
@precio_mayor		numeric(18,2),
@cant_mayor			int,
@impuesto			numeric(18,2),
@tipo_prod			varchar(50)


AS

--Validamos que no se ingresen productos con el mismo nombre y codigo
if exists(SELECT @nombre_prod, @codigo from t_productos 
WHERE nombre_prod=@nombre_prod or codigo=@codigo)
RAISERROR ('El producto y/o el código ya existen en la base de datos, revise bien',16,1)

ELSE


UPDATE t_productos SET

nombre_prod=@nombre_prod,
imagen_prod=@imagen_prod,
nombreimagen=@nombre_imagen,
id_categoria=@id_categoria,
id_subcategoria=@id_subcategoria,
id_marca=@id_marca,
precio_compra=@precio_compra,
precio_venta=@precio_venta,
codigo = @codigo,
precio_mayor=@precio_mayor,
cant_mayor=@cant_mayor,
impuesto=@impuesto,
tipo_prod = @tipo_prod

WHERE id_prod=@id_prod
GO
/****** Object:  StoredProcedure [dbo].[editar_saldoinicial]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editar_saldoinicial]
@id_caja	int,
@saldo		numeric(18,2)

AS

UPDATE t_cierrecaja 

SET saldo=@saldo

WHERE id_caja=@id_caja and estado='CAJA APERTURADA'

GO
/****** Object:  StoredProcedure [dbo].[editar_subcategoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editar_subcategoria]

@id_cat					int,
@nombre_subcat			varchar(50),
@descripcion_subcat		varchar(MAX),
@id_subcat				int

AS

update t_subcategorias set
id_cat = @id_cat,
nombre_subcat=@nombre_subcat,
descripcion_subcat=@descripcion_subcat

where id_subcat=@id_subcat

GO
/****** Object:  StoredProcedure [dbo].[eliminar_categoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_categoria]

@id_cat		int

AS
DELETE FROM t_categorias WHERE id_cat=@id_cat
GO
/****** Object:  StoredProcedure [dbo].[eliminar_cliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_cliente]

@id_cli		int

AS

UPDATE t_clientes SET
estado='ELIMINADO'

WHERE id_cli=@id_cli
GO
/****** Object:  StoredProcedure [dbo].[eliminar_detallereporte]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_detallereporte]

@idprod_rep		int

AS
DELETE FROM t_detallereporte
WHERE idprod_rep = @idprod_rep
GO
/****** Object:  StoredProcedure [dbo].[eliminar_detalleventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_detalleventa]

@producto	int,
@id_venta	int

AS

DELETE FROM t_detalleventa

WHERE producto=@producto AND id_venta=@id_venta 
GO
/****** Object:  StoredProcedure [dbo].[eliminar_fabrica]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_fabrica]
@id_fab	int

AS

DELETE FROM t_fabricas WHERE id_fab=@id_fab
GO
/****** Object:  StoredProcedure [dbo].[eliminar_marca]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_marca]

@id_mar	int

AS

DELETE FROM t_marcas WHERE id_mar=@id_mar
GO
/****** Object:  StoredProcedure [dbo].[eliminar_producto]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_producto]

@id_prod	int

AS

DELETE FROM t_productos WHERE id_prod=@id_prod
GO
/****** Object:  StoredProcedure [dbo].[eliminar_subcategoria]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_subcategoria]
@id_subcat		int

AS

DELETE FROM t_subcategorias WHERE id_subcat=@id_subcat
GO
/****** Object:  StoredProcedure [dbo].[eliminar_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_usuario]

@id_usu		int

AS

UPDATE t_usuarios SET estado='DESACTIVADO'
WHERE id_usu=@id_usu;
GO
/****** Object:  StoredProcedure [dbo].[estado_caja]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[estado_caja]

@id_caja	int

AS

SELECT estado from t_cierrecaja where estado='CAJA APERTURADA' and id_caja=@id_caja
GO
/****** Object:  StoredProcedure [dbo].[evitar_repetido]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[evitar_repetido]

@producto	int,
@id_venta	int

AS

SELECT producto FROM t_detalleventa
WHERE producto=@producto AND id_venta=@id_venta
GO
/****** Object:  StoredProcedure [dbo].[eyectar_cliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eyectar_cliente]

@id_cli		int

AS

DELETE FROM t_clientes
WHERE id_cli=@id_cli
GO
/****** Object:  StoredProcedure [dbo].[filtro_acumulado]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[filtro_acumulado]

@fecha date,
@tipo varchar(50),
@id_usuario int

AS

SELECT t_productos.nombre_prod AS Producto,
 tipo AS Tipo, sum(cantidad) AS CantidadTotal, t_usuarios.usuario AS Encargado

FROM t_kardex

INNER JOIN t_productos ON t_kardex.producto = t_productos.id_prod
INNER JOIN t_usuarios ON t_kardex.usuario = t_usuarios.id_usu

WHERE t_kardex.usuario = @id_usuario AND TRY_CONVERT(date, t_kardex.fecha)=TRY_CONVERT(date,@fecha) and (t_kardex.tipo=@tipo or @tipo='-AMBOS-')
GROUP BY t_productos.nombre_prod, t_usuarios.usuario, t_kardex.tipo
ORDER BY SUM(t_kardex.cantidad) DESC
GO
/****** Object:  StoredProcedure [dbo].[filtros_avanzados_kardex]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[filtros_avanzados_kardex]

@fecha		date,
@tipo		varchar(50),
@usuario	int

AS

SELECT id_kardex, t_kardex.fecha AS Fecha, t_productos.nombre_prod AS Producto, 
motivo AS Detalle, habia AS Había, tipo AS Tipo, cantidad AS Stock, hay AS Hay, t_usuarios.usuario AS Encargado,
t_categorias.nombre_cat AS Categoría, t_subcategorias.nombre_subcat AS Subcategoría

FROM t_kardex

INNER JOIN t_productos ON t_kardex.producto = t_productos.id_prod
INNER JOIN t_usuarios ON t_kardex.usuario = t_usuarios.id_usu
INNER JOIN t_subcategorias ON t_subcategorias.id_subcat=t_productos.id_subcategoria
INNER JOIN t_categorias ON t_categorias.id_cat = t_productos.id_categoria

WHERE CONVERT(date, t_kardex.fecha)=CONVERT(date,@fecha) and (t_kardex.tipo=@tipo or @tipo='TODOS') -- t_kardex.usuario=@usuario
GO
/****** Object:  StoredProcedure [dbo].[insertar_detallereporte]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_detallereporte]

@idprod_rep		int,
@cod_rep		varchar(50),
@prod_rep		varchar(50),
@costo_rep		numeric(18,2),
@precio_rep		numeric(18,2),
@stock_rep		int,
@minimo_rep		int,
@total_rep		numeric(18,2)

AS

if exists (select cod_rep from t_detallereporte where cod_rep=@cod_rep)
raiserror('ESTE PRODUCTO YA ESTÁ SELECCIONADO, PORFAVOR ELIJA OTRO',16,1)
ELSE

INSERT INTO t_detallereporte VALUES
(@idprod_rep,
@cod_rep,
@prod_rep,
@costo_rep,
@precio_rep,
@stock_rep,
@minimo_rep,
@total_rep)


GO
/****** Object:  StoredProcedure [dbo].[insertar_detalleventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_detalleventa]
@id_venta			int,
@id_detalleventa	int,
@producto			int,
@cantidad			int,
@precio_unit		numeric(18,2),
@moneda				varchar(50),
@unidad_medida		varchar(50),
@cant_mostrada		int,
@estado				varchar(50),
@descripcion		varchar(max),
@codigo				varchar(50),
@stock				int,
@unidades			varchar(50),
@usa_inventario		varchar(50),
@costo				numeric(18,2)

AS

INSERT INTO t_detalleventa
VALUES
(@id_venta,
@id_detalleventa,
@producto,
@cantidad,
@precio_unit,
@moneda,
@unidad_medida,
@cant_mostrada,
@estado,
@descripcion,
@codigo,
@stock,
@unidades,
@usa_inventario,
@costo)
GO
/****** Object:  StoredProcedure [dbo].[insertar_entrada]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_entrada]

@fecha		datetime,
@motivo		varchar(50),
@cantidad	int,
@producto	int,
@usuario	int,
@tipo		varchar(50),
@estado		varchar(50),
@costo_unit	numeric(18,2),
@habia		int,
@hay		int,
@id_caja	int

AS

INSERT INTO t_kardex  
VALUES
(@fecha,
@motivo,
@cantidad,
@producto,
@usuario,
@tipo,
@estado,
@costo_unit,
@habia,
@hay,
@id_caja)
GO
/****** Object:  StoredProcedure [dbo].[insertar_producto_importacion]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertar_producto_importacion]

@nombre_prod		varchar(50),
@imagen_prod		image,
@nombre_imagen		varchar(MAX),
@id_categoria		int,
@id_subcategoria	int,
@id_marca			int,
@usa_inventario		varchar(2),
@stock				int,
@precio_compra		numeric(18,2),
@precio_venta		numeric(18,2),
@fecha_venc			date,
@codigo				varchar(50),
@precio_mayor		numeric(18,2),
@cant_mayor			int,
@impuesto			numeric(18,2),
@stock_min			int,
@tipo_prod			varchar(50),

--Ahora creamos los parametros para insertar en tabla kardex
@fecha				datetime,
@motivo				varchar(50),
@cantidad			int,
@usuario			int,
@tipo				varchar(50),
@estado				varchar(50),
@id_caja			int

AS

BEGIN
--Validamos que no se ingresen productos con el mismo nombre y codigo
if exists(SELECT nombre_prod, codigo from t_productos 
WHERE (nombre_prod=@nombre_prod or codigo=@codigo) or nombre_prod='')
RAISERROR ('El producto y/o el código ya existen en la base de datos, revise bien',16,1)

ELSE

BEGIN

DECLARE @producto  int --Capturo el id del producto que voy a ingresar para mandar ese mismo a kardex

INSERT INTO t_productos VALUES
(@nombre_prod,
@imagen_prod,
@nombre_imagen,
@id_categoria,
@id_subcategoria,
@id_marca,
@usa_inventario,
@stock,
@precio_compra,
@precio_venta,
@fecha_venc,
@codigo	,
@precio_mayor,
@cant_mayor,
@impuesto,
@stock_min,
@tipo_prod)

--Ahora seleccionemos el ID del producto
SELECT @producto = SCOPE_IDENTITY()
--Obtenemos los datos de este id

DECLARE @hay	as int
DECLARE @habia	as int
DECLARE @costo_unit as numeric(18,2)

SET @hay = (SELECT stock from t_productos WHERE id_prod=@producto and usa_inventario='SI')
SET @costo_unit = (SELECT precio_compra from t_productos WHERE id_prod=@producto)
SET @habia = 0

--Ahora comprobaremos si ese producto digitado usa inventario o no
SET @usa_inventario = (SELECT usa_inventario from t_productos WHERE id_prod=@producto and usa_inventario='SI')

if @usa_inventario='SI'

BEGIN

INSERT INTO t_kardex VALUES
(@fecha,
@motivo,
@cantidad,
@producto,
@usuario,
@tipo,
@estado,
@costo_unit,
@habia,
@hay,
@id_caja
)
END

BEGIN 
			UPDATE t_productos SET codigo=t_productos.id_prod
		WHERE codigo='VACIO@'
		END
		
		BEGIN
			DELETE FROM t_productos WHERE nombre_prod='VACIO@'
		END

		BEGIN
			DELETE FROM t_productos WHERE nombre_prod='Descripcion'
		END
END
END

GO
/****** Object:  StoredProcedure [dbo].[inventarios_bajos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inventarios_bajos]
AS
SELECT id_kardex, t_productos.codigo AS Código, t_productos.nombre_prod AS Producto, 
costo_unit AS PrecioCompra, t_categorias.nombre_cat AS Categoria, t_subcategorias.nombre_subcat AS Subcategoria, 
hay AS Stock, t_productos.stock_min AS Mínimo

FROM t_kardex

INNER JOIN t_productos ON t_kardex.producto = t_productos.id_prod
INNER JOIN t_usuarios ON t_kardex.usuario = t_usuarios.id_usu
INNER JOIN t_subcategorias ON t_subcategorias.id_subcat=t_productos.id_subcategoria
INNER JOIN t_categorias ON t_categorias.id_cat = t_productos.id_categoria

WHERE hay <= t_productos.stock_min
GO
/****** Object:  StoredProcedure [dbo].[invocar_rol_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[invocar_rol_usuario]

@usuario		varchar(50)

AS

select t_rol.nombre_rol

from t_usuarios 

INNER JOIN t_rol on t_usuarios.rol_usu=t_rol.id_rol

--INNER JOIN $tablaajena ON losquecoinciden t_usuarios.rol_usu=t_rol.id_rol

where usuario=@usuario

GO
/****** Object:  StoredProcedure [dbo].[invocar_saldo]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[invocar_saldo]

@id_caja	int

AS

select saldo from t_cierrecaja where id_caja=@id_caja and estado='CAJA APERTURADA'
GO
/****** Object:  StoredProcedure [dbo].[listar_categorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listar_categorias]
AS
SELECT id_cat, nombre_cat from t_categorias
GO
/****** Object:  StoredProcedure [dbo].[listar_fabricas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listar_fabricas]

AS

SELECT id_fab, nombre_fab from t_fabricas
GO
/****** Object:  StoredProcedure [dbo].[listar_usuarios_kardex]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listar_usuarios_kardex]
AS
SELECT DISTINCT t_kardex.usuario AS id_usu, t_usuarios.usuario AS Usuario
FROM t_kardex

INNER JOIN t_usuarios ON t_kardex.usuario=t_usuarios.id_usu
GO
/****** Object:  StoredProcedure [dbo].[mostrar_categorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_categorias]
AS
select id_cat as 'ID', cod_cat as 'Código', nombre_cat as 'Categorías', descripcion_cat as 'Descripción' from t_categorias;
GO
/****** Object:  StoredProcedure [dbo].[mostrar_clave_correo]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrar_clave_correo]

@correo		varchar(max)

AS

SELECT clave FROM t_usuarios WHERE correo = @correo
GO
/****** Object:  StoredProcedure [dbo].[mostrar_clientes]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_clientes]

AS

SELECT id_cli, CONCAT(prinom_cli,' ',segnom_cli,' ', app_cli,' ', apm_cli) AS Cliente, prinom_cli, segnom_cli, app_cli, apm_cli, fecha_cli, genero,
t_tipocliente.nombre_tipo AS 'Tipo', email, telefono, celular, direccion, dni, foto_cli, nombrefoto, estado
FROM t_clientes
INNER JOIN t_tipocliente ON t_clientes.tipo_cli=t_tipocliente.id_tipo
GO
/****** Object:  StoredProcedure [dbo].[mostrar_correo_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_correo_usuario]

@usuario		varchar(50)

AS

SELECT correo FROM t_usuarios WHERE usuario = @usuario
GO
/****** Object:  StoredProcedure [dbo].[mostrar_detallereporte]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_detallereporte]

AS

SELECT idprod_rep, cod_rep AS Código, prod_rep AS Producto, costo_rep AS Costo, precio_rep AS PrecioVenta, stock_rep AS Stock, minimo_rep AS Mínimo, total_rep AS Importe
FROM t_detallereporte
GO
/****** Object:  StoredProcedure [dbo].[mostrar_detalleventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_detalleventa]

@id_venta	int

AS

SELECT id_venta,id_detalleventa, codigo, producto,descripcion, cantidad, precio_unit, total_pagar, stock FROM t_detalleventa

WHERE id_venta=@id_venta
GO
/****** Object:  StoredProcedure [dbo].[mostrar_fabricas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_fabricas]

AS

SELECT id_fab AS 'ID', cod_fab AS 'Código', nombre_fab AS 'Fábrica', descripcion_fab AS 'Descripción', logo_fab, nombrelogo_fab FROM t_fabricas;
GO
/****** Object:  StoredProcedure [dbo].[mostrar_fotoperfil]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_fotoperfil]

@usuario	varchar(50)

AS

select icono 
from t_usuarios 
where usuario=@usuario
GO
/****** Object:  StoredProcedure [dbo].[mostrar_idcaja_serial]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_idcaja_serial]

@serial		varchar(50)

AS

SELECT id_caja, descripcion from t_caja where serial_pc= @serial

GO
/****** Object:  StoredProcedure [dbo].[mostrar_idusuario_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_idusuario_usuario]

@usuario	varchar(50)

AS

select id_usu 
from t_usuarios 
where usuario=@usuario
GO
/****** Object:  StoredProcedure [dbo].[mostrar_marcas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_marcas]
AS
select id_mar AS 'ID', cod_mar AS 'Código', nombre_mar AS 'Marcas', t_fabricas.nombre_fab AS 'Fábrica', logo_mar, nombrelogo_mar
from t_marcas

--innerjoin $tablaajena ON comunA=comunB
inner join t_fabricas on t_marcas.id_fab = t_fabricas.id_fab
GO
/****** Object:  StoredProcedure [dbo].[mostrar_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_productos]
AS
SELECT id_prod AS 'ID', nombre_prod AS 'Producto', imagen_prod, nombreimagen, 
id_categoria, t_categorias.nombre_cat AS 'Categoría', id_subcategoria, t_subcategorias.nombre_subcat AS 'Subcategoría', id_marca, t_marcas.nombre_mar AS 'Marca',
usa_inventario, stock AS 'Stock', precio_compra, precio_venta AS 'Precio Venta', fecha_venc, codigo AS 'Código', precio_mayor AS 'Precio x Mayor', cant_mayor AS 'A partir de', 
impuesto, stock_min, tipo_prod
from t_productos
INNER JOIN t_categorias ON t_productos.id_categoria=t_categorias.id_cat
INNER JOIN t_subcategorias ON t_productos.id_subcategoria=t_subcategorias.id_subcat
INNER JOIN t_marcas ON t_productos.id_marca=t_marcas.id_mar
GO
/****** Object:  StoredProcedure [dbo].[mostrar_productos_entradas]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_productos_entradas] 

@id_prod	int

AS

SELECT TOP 1 id_prod, codigo, nombre_prod, precio_compra, habia, precio_venta, stock+t_kardex.habia AS Actual 
FROM t_productos
INNER JOIN t_kardex ON t_productos.id_prod=t_kardex.producto
WHERE id_prod = @id_prod AND estado='CONFIRMO'
ORDER BY id_kardex desc
GO
/****** Object:  StoredProcedure [dbo].[mostrar_productos_vencidos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_productos_vencidos]
AS
SELECT id_prod, codigo AS Código, nombre_prod AS Producto, fecha_venc AS 'FechaVencimiento', stock AS Stock,
DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) AS 'Días'
FROM t_productos where fecha_venc<>'NO APLICA' AND TRY_CONVERT(date, fecha_venc) <= TRY_CONVERT(date,GETDATE()) 
GO
/****** Object:  StoredProcedure [dbo].[mostrar_subcategorias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_subcategorias]
AS
select id_subcat AS 'ID', cod_subcat AS 'Código', t_categorias.nombre_cat AS 'Categoría', nombre_subcat AS 'Subcategoría', descripcion_subcat AS 'Descripción',t_categorias.id_cat 
from t_subcategorias
inner join t_categorias on t_subcategorias.id_cat = t_categorias.id_cat
GO
/****** Object:  StoredProcedure [dbo].[mostrar_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrar_usuario]

AS

SELECT id_usu, prinom_usu as PrimerNombre, segnom_usu as SegundoNombre, app_usu as ApellidoPaterno, apm_usu as ApellidoMaterno, fecha_nac as FechaNacimiento, usuario as Usuario, genero, rol_usu, correo, icono, nom_icono, clave, estado
FROM t_usuarios
WHERE estado='ACTIVADO';
GO
/****** Object:  StoredProcedure [dbo].[movimientos_almacen]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[movimientos_almacen]

@fecha	date

AS

select id AS ID, fecha AS Fecha, tipo AS Acción, motivo, cantidad AS Cantidad, producto, t_productos.nombre_prod 
FROM t_almacen
INNER JOIN t_productos ON t_almacen.producto=t_productos.id_prod
WHERE fecha=@fecha
GO
/****** Object:  StoredProcedure [dbo].[procesar_venta]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procesar_venta]

@cliente			int,
@fecha_venta		datetime,
@num_doc			varchar(50),
@monto_total		numeric(18,2),
@tipo_pago			varchar(50),
@estado				varchar(50),
@boleta				varchar(50),
@usuario			int,
@fecha_pago			datetime,
@accion				varchar(50),
@pago_parcial		numeric(18,2),
@porc_igv			numeric(18,2),
@caja				int,
@referencia_card	int,
@efectivo			numeric(18,2),
@credito			varchar(50),
@tarjeta			varchar(50),
@id_venta			int

AS

UPDATE t_ventas SET
cliente=@cliente,
fecha_venta=@fecha_venta,
num_doc=@num_doc,
monto_total=@monto_total,
tipo_pago=@tipo_pago,
estado=@estado,
boleta=@boleta,
usuario=@usuario,
fecha_pago=@fecha_pago,
accion=@accion,
pago_parcial=@pago_parcial,
porc_igv=@porc_igv,
caja=@caja,
referencia_card=@referencia_card,
efectivo=@efectivo,
credito=@credito,
tarjeta=@tarjeta
	
WHERE id_venta=@id_venta
GO
/****** Object:  StoredProcedure [dbo].[productos_30dias]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productos_30dias]

AS

SELECT id_prod, codigo AS Código, nombre_prod AS Producto, fecha_venc AS 'FechaVencimiento', stock AS Stock,
DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) AS 'Días'
FROM t_productos where fecha_venc<>'NO APLICA' AND TRY_CONVERT(date, fecha_venc) > TRY_CONVERT(date,GETDATE()) 
AND (DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) BETWEEN 1 AND 30)
GO
/****** Object:  StoredProcedure [dbo].[pruebadetalle]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pruebadetalle]

@id_venta			int,
@id_detalleventa	int,
@descripcion		varchar(50)

AS

INSERT INTO t_detalleventa(id_venta,id_detalleventa, descripcion)
VALUES(@id_venta, @id_detalleventa, @descripcion)	
GO
/****** Object:  StoredProcedure [dbo].[pruebamostrardetalle]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pruebamostrardetalle]

@id_venta	int

AS

SELECT * from t_detalleventa
WHERE id_venta=@id_venta  	
GO
/****** Object:  StoredProcedure [dbo].[pruebatraer_idventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pruebatraer_idventa]

AS

SELECT TOP 1 id_venta FROM t_ventas
ORDER BY id_venta DESC

GO
/****** Object:  StoredProcedure [dbo].[realizar_kardex]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[realizar_kardex]

@id_prod	int

AS

SELECT id_kardex, fecha, tipo, t_productos.nombre_prod, cantidad, costo_unit, total, hay,  total+cantidad*habia AS NuevoTotal, CONVERT(numeric(18,2), ((total+cantidad*habia)/hay)) AS NuevoPrecioUnit
FROM t_kardex
INNER JOIN t_productos ON t_kardex.producto = t_productos.id_prod

WHERE producto=@id_prod
GO
/****** Object:  StoredProcedure [dbo].[reporte_productos]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reporte_productos]

AS

select id_prod, codigo AS Código, nombre_prod AS Producto, precio_compra AS Costo, precio_venta AS 'PrecioVenta', stock AS Stock, stock_min AS Mínimo,
t_categorias.nombre_cat AS Categoría, t_subcategorias.nombre_subcat AS Subcategoría, t_marcas.nombre_mar AS Marca,
precio_compra*stock AS Importe
FROM t_productos
INNER JOIN t_categorias ON t_productos.id_categoria=t_categorias.id_cat
INNER JOIN t_subcategorias	ON t_productos.id_subcategoria = t_subcategorias.id_subcat
INNER JOIN t_marcas	ON t_productos.id_marca = t_marcas.id_mar
GO
/****** Object:  StoredProcedure [dbo].[restaurar_cliente]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[restaurar_cliente]

@id_cli		int

AS

UPDATE t_clientes SET
estado='ACTIVADO'

WHERE id_cli=@id_cli
GO
/****** Object:  StoredProcedure [dbo].[sumar_inventario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sumar_inventario]
AS
SELECT SUM(total) AS CostoInventario FROM t_kardex;
GO
/****** Object:  StoredProcedure [dbo].[sumar_inversion]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sumar_inversion]
AS
SELECT SUM(precio_compra*stock) AS TotalInversion FROM t_productos;
GO
/****** Object:  StoredProcedure [dbo].[sumatoria_venta]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sumatoria_venta]

@id_venta	int

AS

SELECT SUM(total_pagar) AS Total FROM t_detalleventa
WHERE id_venta=@id_venta
GO
/****** Object:  StoredProcedure [dbo].[terminar_detalleventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[terminar_detalleventa]

@id_venta		int,
@estado			varchar(50)

AS

UPDATE t_detalleventa SET

estado=@estado

WHERE id_venta= @id_venta
GO
/****** Object:  StoredProcedure [dbo].[traer_idventa]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[traer_idventa]

AS

SELECT TOP 1 id_venta FROM t_ventas
ORDER BY id_venta DESC
GO
/****** Object:  StoredProcedure [dbo].[vaciar_detallereporte]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vaciar_detallereporte]

AS

delete from t_detallereporte
GO
/****** Object:  StoredProcedure [dbo].[validar_usuario]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[validar_usuario]

@usuario	varchar(50),
@clave		varchar(50)

AS 

SELECT id_usu, prinom_usu, app_usu, rol_usu 
FROM t_usuarios
WHERE usuario=@usuario and clave=@clave
GO
/****** Object:  StoredProcedure [dbo].[vencimiento_dinamico]    Script Date: 15/11/2020 10:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vencimiento_dinamico]

@dias		int

AS

SELECT id_prod, codigo AS Código, nombre_prod AS Producto, fecha_venc AS 'FechaVencimiento', stock AS Stock,
DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) AS 'Días'
FROM t_productos where fecha_venc<>'NO APLICA' AND TRY_CONVERT(date, fecha_venc) > TRY_CONVERT(date,GETDATE()) 
AND (DATEDIFF(day, TRY_CONVERT(date,GETDATE()),TRY_CONVERT(date, fecha_venc)) BETWEEN 1 AND @dias)
GO
USE [master]
GO
ALTER DATABASE [BD_I2_Bodega] SET  READ_WRITE 
GO
