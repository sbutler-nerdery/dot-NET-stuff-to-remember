Ok, after several hours of messing with this, I was finally able to get twitter bootstrap to compile down to a css file using:
http://visualstudiogallery.msdn.microsoft.com/07d54d12-7133-4e15-becb-6f451ea3bea6

Web Essentials 2012 has several options, including the ability to compile less files when you save them. It will also generate minified css as well.

Note: in order to get the less files to compile properly, you have to open bootstrap.less, which imports all of the other files. 
THEN you will see all of the outputed CSS in the preview window. 

WARNING: before trying the web essetnials 2012, I tried dotless and this could not compile the newest bootstrap less files!!
