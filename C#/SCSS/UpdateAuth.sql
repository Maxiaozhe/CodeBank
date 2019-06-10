begin tran
update M_Poem2 SET
Author = S.AUTH,
Title=S.TITLE,
Dynasty=S.DYNASTY
From
M_Poem2 AS M inner join (
select 
 B.ID,
 LEFT( B.AUTH,CHARINDEX('·', B.AUTH)-1) AS DYNASTY,
 SUBSTRING( B.AUTH,CHARINDEX('·', B.AUTH)+1,LEN(B.AUTH)) AS AUTH,
 LEFT(B.Title,B.CSTART-2) AS TITLE
from
(
select
A.ID,
SUBSTRING(A.Title,A.CSTART,A.CEND-A.CSTART) AS AUTH,
A.Title,
A.CSTART,
A.CEND,
A.CEND-A.CSTART as leng
from
(
select 
ID,
CHARINDEX('(', TITLE)+1 AS CSTART,
CHARINDEX(')', TITLE,CHARINDEX('(', TITLE)) AS CEND,Title 
from M_Poem2 
where ISNULL(Author,'')=''
) AS A
where 
A.CEND-A.CSTART >0
) AS B
where
CHARINDEX('·', B.AUTH)>1
) AS S ON( M.ID=S.ID)


commit


select 
*
from M_Poem2 
where ISNULL(Author,'')=''
