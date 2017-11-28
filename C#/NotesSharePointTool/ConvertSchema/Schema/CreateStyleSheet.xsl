<?xml version="1.0" encoding="UTF-8"?>
<!-- 
***********************************************************************************    
    name             : CreateStyleSheet.xsl
    Version          : v1.01
    Author           : Susumu Hasegawa@RITS
    Create Date      : 2010.07.13
    Updated By       : Yoshiki Tsuji@RITS
    Update Date      : 2014.02.27
    Copyrignt        : Ricoh IT Solutuons's Co.,LTD.
***********************************************************************************    
-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dxl="http://www.lotus.com/dxl" version="1.0">
 <xsl:output method="xml" indent="yes" encoding="UTF-8"/>
 <xsl:include href="./core.xsl" />
 <xsl:param name="richtextlist"/>

 <xsl:template match="/dxl:document">
  <xsl:element name="xsl:stylesheet" >
   <xsl:attribute namespace="http://www.lotus.com/dxl" name="dxl:ab"/>
<!--
	<xsl:attribute name="xmlns:xsl">http://www.w3.org/1999/XSL/Transform</xsl:attribute>
	<xsl:attribute name="xmlns:dxl">http://www.lotus.com/dxl</xsl:attribute>
-->
   <xsl:attribute name="version">1.0</xsl:attribute>
   <xsl:element name="xsl:output">
    <xsl:attribute name="method">html</xsl:attribute>
    <xsl:attribute name="indent">yes</xsl:attribute>
    <xsl:attribute name="encoding">UTF-8</xsl:attribute>
   </xsl:element>

   <xsl:call-template name="grobal-variable-block"/>

   <xsl:element name="xsl:template">
    <xsl:attribute name="match">/dxl:document</xsl:attribute>

     <xsl:element name="html">
      <xsl:element name="head">

       <xsl:element name="meta">
        <xsl:attribute name="http-equiv"><xsl:text>X-UA-Compatible</xsl:text></xsl:attribute>
        <xsl:attribute name="content"><xsl:text>IE=5</xsl:text></xsl:attribute>
       </xsl:element>

       <xsl:element name="title">
        <xsl:element name="xsl:value-of">
         <xsl:attribute name="select">
          <xsl:text>dxl:item[@name=$HtmlTitle]//text()</xsl:text>
         </xsl:attribute>
        </xsl:element>
       </xsl:element>

       <xsl:call-template name="script-block"/>

       <xsl:element name="style">
        <!--フォームレイアウトのCSS定義部-->
        <xsl:for-each select="//dxl:pardef">
         <xsl:call-template name="pardef"/>
        </xsl:for-each>

        <!-- par要素のdef属性が取得できなかった場合の標準スタイル -->
        <xsl:text>
		.defaultclass0{
				padding-left:1in;
				line-height:normal;
				text-align:left;
			}
      </xsl:text>

        <xsl:element name="xsl:for-each">
         <xsl:attribute name="select">//dxl:pardef</xsl:attribute>
         <xsl:element name="xsl:call-template">
          <xsl:attribute name="name">pardef</xsl:attribute>
         </xsl:element>
        </xsl:element>

        <!--セクション動作のJavaScript関数部-->
        <xsl:call-template name="css-block"/>
       </xsl:element>

      </xsl:element>

      <xsl:element name="body">
       <xsl:attribute name="scroll">auto</xsl:attribute>
       <xsl:attribute name="class">grid</xsl:attribute>

       <xsl:element name="xsl:attribute">
        <xsl:attribute name="name">
         <xsl:text>bgcolor</xsl:text>
        </xsl:attribute>
        <xsl:element name="xsl:value-of">
         <xsl:attribute name="select">
          <xsl:text>$BgColor</xsl:text>
         </xsl:attribute>
        </xsl:element>
       </xsl:element>
<!-- 
<xsl:element name="xsl:call-template">
	<xsl:attribute name="name">header</xsl:attribute>
</xsl:element>
 -->

<xsl:text disable-output-escaping="yes"><![CDATA[
<!-- 
***************************************************************************
フォームレイアウトの記述（ここから）
***************************************************************************-->
]]></xsl:text>

<xsl:if test="dxl:item[@name='TargetForm']//text()!=''">
	<xsl:apply-templates select="dxl:item[@name='TargetForm']"/>
</xsl:if>

<!-- アイテム外の添付ファイルを表示 -->
<xsl:call-template name="outside-attachment-block"/>

<xsl:text disable-output-escaping="yes"><![CDATA[
<!-- 
***************************************************************************
フォームレイアウトの記述（ここまで）
***************************************************************************-->
]]></xsl:text>

<!-- 
<xsl:element name="xsl:call-template">
	<xsl:attribute name="name">footer</xsl:attribute>
</xsl:element>
 -->
</xsl:element>
</xsl:element>
</xsl:element>
</xsl:element>
</xsl:template>
</xsl:stylesheet>