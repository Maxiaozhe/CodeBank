------------------------------CREATE TABLE:{0}【{1}】---------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[{0}](
{2}{3}
) ON [PRIMARY]
END
GO
