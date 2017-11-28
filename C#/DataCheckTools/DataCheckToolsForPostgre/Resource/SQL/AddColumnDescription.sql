
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'{0}', N'COLUMN',N'{1}'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{2}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{0}', @level2type=N'COLUMN',@level2name=N'{1}'
GO
