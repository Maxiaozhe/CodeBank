﻿/*作成済みの稼動キーNOを取得する*/
 SELECT 
	OPERATION_PLAN_NO
 FROM 
	ACTION_HISTORY_OPERATION 
 Where 
	 FACILITY_CODE=@FACILITY_CODE
 AND OPERATION_DATE=@OPERATION_DATE