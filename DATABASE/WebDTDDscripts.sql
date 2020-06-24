USE [Demo DTDD]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[Category_name] [varchar](50) NULL,
	[Parent_ID] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Comment_ID] [int] NOT NULL,
	[Phone_ID] [int] NULL,
	[Fullname] [varchar](50) NULL,
	[Comment_time] [datetime] NULL,
	[Comment_content] [varchar](max) NULL,
	[Phone_number] [varchar](50) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Comment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] NOT NULL,
	[Customer_name] [varchar](50) NULL,
	[Customer_phone] [varchar](50) NULL,
	[Customer_mail] [varchar](100) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deliverer]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliverer](
	[Deliverer_ID] [int] NOT NULL,
	[Deliverer_name] [varchar](50) NULL,
	[Deliverer_phone] [varchar](50) NULL,
 CONSTRAINT [PK_Deliverer] PRIMARY KEY CLUSTERED 
(
	[Deliverer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_ID] [int] NOT NULL,
	[Customer_ID] [int] NULL,
	[Status_ID] [int] NULL,
	[Deliverer_ID] [int] NULL,
	[Create_date] [datetime] NULL,
	[Total_price] [varchar](max) NULL,
	[Delivery_address] [varchar](max) NULL,
	[Note] [varchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_detail]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_detail](
	[Order_detail_ID] [int] NOT NULL,
	[Order_ID] [int] NULL,
	[Product_ID] [int] NULL,
	[Price] [varchar](max) NULL,
	[Sale_quantity] [int] NULL,
 CONSTRAINT [PK_Order_detail] PRIMARY KEY CLUSTERED 
(
	[Order_detail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] NOT NULL,
	[ID_cat] [int] NULL,
	[ProductName] [varchar](max) NULL,
	[Title] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Price] [varchar](max) NULL,
	[Quantity] [int] NULL,
	[Size] [varchar](max) NULL,
	[Weight] [varchar](max) NULL,
	[Color] [varchar](max) NULL,
	[Image] [varchar](max) NULL,
	[Memory] [varchar](max) NULL,
	[OS] [varchar](max) NULL,
	[CPU_speed] [varchar](max) NULL,
	[Camera_primary] [varchar](max) NULL,
	[Battery] [varchar](max) NULL,
	[Bluetooth] [varchar](max) NULL,
	[Wlan] [varchar](max) NULL,
	[Promotion_price] [varchar](max) NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_phones]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_phones](
	[ID] [int] NOT NULL,
	[Phone_ID] [int] NULL,
	[Quantity] [int] NULL,
	[Create_date] [datetime] NULL,
 CONSTRAINT [PK_Sale_phones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Status_ID] [int] NOT NULL,
	[Status] [varchar](max) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/24/2020 6:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [int] NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Product] FOREIGN KEY([Phone_ID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Deliverer] FOREIGN KEY([Deliverer_ID])
REFERENCES [dbo].[Deliverer] ([Deliverer_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Deliverer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([Status_ID])
REFERENCES [dbo].[Status] ([Status_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_detail_Order] FOREIGN KEY([Order_ID])
REFERENCES [dbo].[Order] ([Order_ID])
GO
ALTER TABLE [dbo].[Order_detail] CHECK CONSTRAINT [FK_Order_detail_Order]
GO
ALTER TABLE [dbo].[Order_detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_detail_Product] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Order_detail] CHECK CONSTRAINT [FK_Order_detail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ID_cat])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Sale_phones]  WITH CHECK ADD  CONSTRAINT [FK_Sale_phones_Product] FOREIGN KEY([Phone_ID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Sale_phones] CHECK CONSTRAINT [FK_Sale_phones_Product]
GO
