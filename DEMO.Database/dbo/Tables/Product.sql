CREATE TABLE [dbo].[Product] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]     INT            NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [Attribute]      NVARCHAR (100) NOT NULL,
    [Price]          INT            NOT NULL,
    [PromotionPrice] INT            NULL,
    [LimitCount]     INT            NOT NULL,
    [SpecNote]       NVARCHAR (255) CONSTRAINT [DF_Product_SpecNote] DEFAULT ('') NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [ActiveSDate]    DATETIME       NOT NULL,
    [ActiveEDate]    DATETIME       NOT NULL,
    [ActiveEnable]   BIT            NOT NULL,
    [IsDelete]       BIT            NOT NULL,
    [CreatedOnUtc]   DATETIME       NOT NULL,
    [ModifiedOnUtc]  DATETIME       NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProductCategory] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'異動時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'ModifiedOnUtc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'CreatedOnUtc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'刪除狀態', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'IsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'允許上架狀態（True：允許，False：不允許）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'ActiveEnable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'下架時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'ActiveEDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'上架時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'ActiveSDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品說明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品規格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'SpecNote';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'可購買商品數', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'LimitCount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'售價', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'PromotionPrice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原價', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Price';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品屬性', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Attribute';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'流水識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Id';

