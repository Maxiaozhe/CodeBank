
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'COMMENT' , N'SCHEMA',N'dbo', N'TABLE',N'{0}',NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'COMMENT', @value=N'{1}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{0}'
GO
