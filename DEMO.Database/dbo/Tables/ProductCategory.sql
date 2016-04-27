CREATE TABLE [dbo].[ProductCategory] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [IsDelete]      BIT           CONSTRAINT [DF_ProductCategory_IsDelete] DEFAULT ((0)) NOT NULL,
    [CreatedOnUtc]  DATETIME      CONSTRAINT [DF_ProductCategory_CreatedOnUtc] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedOnUtc] DATETIME      NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'異動時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductCategory', @level2type = N'COLUMN', @level2name = N'ModifiedOnUtc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductCategory', @level2type = N'COLUMN', @level2name = N'CreatedOnUtc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'刪除狀態', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductCategory', @level2type = N'COLUMN', @level2name = N'IsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'分類名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductCategory', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'流水識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductCategory', @level2type = N'COLUMN', @level2name = N'Id';

