<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dxl="http://www.lotus.com/dxl" version="1.0">
<xsl:output method="text" indent="yes" encoding="UTF-8"/>
 <!--
**********************************************************************
パラメータ定義
********************************************************************** -->
<!-- タイトル名 -->
<xsl:param name="HtmlTitle"></xsl:param>
<!-- 背景色 -->
<xsl:param name="BgColor"></xsl:param>
<!-- リンクフラグ -->
<xsl:param name="NotesLinkEnable">1</xsl:param>
<!-- トライアルフラグ -->
<xsl:param name="TrialFlg">1</xsl:param>
<!-- XSL作成モードフラグ -->
<xsl:param name="CreateMode">xsl</xsl:param>
<!-- URLホットスポットフラグ -->
<xsl:param name="HotspotEnable">1</xsl:param>

<!--FontName-->
<xsl:param name="SansSerif"></xsl:param>
<xsl:param name="Serif"></xsl:param>
<xsl:param name="Monospace"></xsl:param>

<!-- アイテム外の添付ファイル名リスト -->
<xsl:param name="OutsideAttachments"></xsl:param>
<xsl:param name="AttachmentDirectory"></xsl:param>

<!-- $REFアイテム -->
<xsl:param name="REF"></xsl:param>

<!-- 画像ファイル固定部 -->
<xsl:param name="image_fix"></xsl:param>

<!-- フォーム変換設定文書ID -->
<xsl:param name="formUnid"></xsl:param>

<xsl:param name="imgsrc">./</xsl:param>
<!--
**********************************************************************
変数定義
********************************************************************** -->
<!-- Dominoバージョン -->
<xsl:variable name="nd_version"><xsl:value-of select="dxl:document/@version"/></xsl:variable>
<!-- ユニバーサルID -->
<xsl:variable name="unid"><xsl:value-of select="dxl:document/dxl:noteinfo/@unid"/></xsl:variable>
<!-- レプリカID -->
<xsl:variable name="replicaid"><xsl:value-of select="dxl:document/@replicaid"/></xsl:variable>
<!-- 空文字 -->
<xsl:variable name="kara"><xsl:text> </xsl:text></xsl:variable>
<!-- アンパサンド -->
<xsl:variable name="amp">&#38;</xsl:variable>
<!-- シングルクォーテーション -->
<xsl:variable name="apos"><xsl:text>'</xsl:text></xsl:variable>
<!-- 半角文字 -->
<xsl:variable name="OneByteChars">
 <xsl:text> !"#$%&amp;'()*+,-./0123456789:;&lt;=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｬｭｮｯｰﾞﾟ｡｢｣､･</xsl:text>
</xsl:variable>
<!-- 縦棒 -->
<xsl:variable name="v_var">|</xsl:variable>

<!-- デフォルトフォントファミリー -->
<xsl:variable name="SansSerifFamily"><xsl:value-of select="$SansSerif"/><xsl:text> sans-serif</xsl:text></xsl:variable>
<xsl:variable name="SerifFamily"><xsl:value-of select="$Serif"/><xsl:text> serif</xsl:text></xsl:variable>
<xsl:variable name="MonospaceFamily"><xsl:value-of select="$Monospace"/><xsl:text> monospace</xsl:text></xsl:variable>


<!--
**********************************************************************
グローバル変数ブロック
********************************************************************** -->
<xsl:template name="grobal-variable-block">
</xsl:template>

<!--
**********************************************************************
JavaScript
********************************************************************** -->
<xsl:template name="script-block">
 <script type="text/javascript" src="../../jquery/jquery.min.js"></script>
 <script type="text/javascript" src="../../jquery/ui.core.js"></script>
 <script type="text/javascript" src="../../jquery/ui.tabs.js"></script>
 <link href="../../jquery/ui.tabs.css" rel="stylesheet" type="text/css" />

 <script type="text/javascript" src="../../jquery/jcaption.min.js"></script>
 <xsl:element name="script">
  <xsl:attribute name="type"><xsl:text>text/javascript</xsl:text></xsl:attribute>
   <xsl:text disable-output-escaping="yes"><![CDATA[
 function section_expand(gid) {
  var c = document.getElementById(gid).style;
  c.display=c.display=='none'?'block':'none';
  var sectiondiv = event.srcElement;
  while(sectiondiv.tagName!='DIV'){
   sectiondiv = sectiondiv.parentElement;
  }
  if(sectiondiv.style.backgroundImage)
   sectiondiv.style.backgroundImage=c.display=='none'?'url(section_r.gif)':'url(section_d.gif)';
 }

 <!-- jcaptionを利用して画像にキャプションを付与 -->
 $(function(){
  $('img.hasCaption').jcaption({
   wrapperElement: 'span',
   imageAttr: 'title',
   copyStyle: true,
   removeStyle: false
  });
 });
   ]]></xsl:text>
 </xsl:element>

</xsl:template>

<!--
**********************************************************************
アイテム外の添付ファイルを表示
********************************************************************** -->
<xsl:template name="outside-attachment-block">
 <xsl:element name="xsl:if">
  <xsl:attribute name="test"><xsl:text>$OutsideAttachments!=''</xsl:text></xsl:attribute>
  <xsl:element name="xsl:call-template">
   <xsl:attribute name="name"><xsl:text>OutputOutsideAttachments</xsl:text></xsl:attribute>
  </xsl:element>
 </xsl:element>
</xsl:template>

<xsl:template name="OutputOutsideAttachments">
 <xsl:element name="div">
  <xsl:attribute name="class"><xsl:text>defaultclass0</xsl:text></xsl:attribute>
  <xsl:element name="hr"/>
  <xsl:element name="p">
   <xsl:element name="font">
    <xsl:attribute name="style"><xsl:text>font-size:10pt;</xsl:text></xsl:attribute>
    <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
   </xsl:element>
  </xsl:element>
  <xsl:element name="div">
   <xsl:attribute name="style"><xsl:text>cursor:pointer;margin-left:0px;padding-left:20px;background:url(></xsl:text><xsl:value-of select="$imgsrc"/><xsl:text>section_d.gif ) no-repeat;zoom:1;</xsl:text></xsl:attribute>
   <xsl:attribute name="onclick"><xsl:text></xsl:text>section_expand('OutsideAttachments')</xsl:attribute>
   <xsl:element name="p">
    <xsl:attribute name="style"><xsl:text>text-indent:0in;text-align:left;</xsl:text></xsl:attribute>
    <xsl:element name="font">
     <xsl:attribute name="style"><xsl:text>white-space:normal;font-size:10pt;</xsl:text></xsl:attribute>
     <xsl:call-template name="GetCountOfOutsideAttachments">
      <xsl:with-param name="list" select="$OutsideAttachments"/>
      <xsl:with-param name="count" select="1"/>
     </xsl:call-template>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
     <xsl:text>添付ファイル</xsl:text>
    </xsl:element>
   </xsl:element>
  </xsl:element>
  <xsl:element name="div">
   <xsl:attribute name="id"><xsl:text>OutsideAttachments</xsl:text></xsl:attribute>
   <xsl:element name="p">
    <xsl:call-template name="OutputOutsideAttachment">
     <xsl:with-param name="list" select="$OutsideAttachments"/>
    </xsl:call-template>
   </xsl:element>
  </xsl:element>
 </xsl:element>
</xsl:template>

<xsl:template name="GetCountOfOutsideAttachments">
 <xsl:param name="list"/>
 <xsl:param name="count"/>
 <xsl:choose>
  <xsl:when test="contains($list, $v_var)">
   <xsl:call-template name="GetCountOfOutsideAttachments">
    <xsl:with-param name="list" select="substring-after($list, $v_var)"/>
    <xsl:with-param name="count" select="number($count) + 1"/>
   </xsl:call-template>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of select="$count"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<xsl:template name="OutputOutsideAttachment">
 <xsl:param name="list"/>
 <xsl:variable name="attachmentName">
  <xsl:choose>
   <xsl:when test="contains($list, $v_var)">
    <xsl:value-of select="substring-before($list, $v_var)"/>
   </xsl:when>
   <xsl:otherwise>
    <xsl:value-of select="$list"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:variable>

 <xsl:if test="$attachmentName!=''">
  <xsl:text disable-output-escaping='yes'>&lt;a style='text-decoration:none;' target='_blank' href="</xsl:text>
   <xsl:value-of select='$imgsrc'/><xsl:value-of select="$AttachmentDirectory"/><xsl:value-of select="substring-after($attachmentName, ':')"/>
  <xsl:text disable-output-escaping='yes'>"></xsl:text>
   <xsl:element name="span">
    <xsl:attribute name="style">
     <xsl:text>display:inline-block;text-indent:0in;background: url(</xsl:text><xsl:value-of select="$imgsrc" /><xsl:text>attachicon.gif</xsl:text>
     <xsl:text>) no-repeat top center;text-align:center;height:47px;cursor:pointer;</xsl:text>

     <!-- 幅を指定する必要があるかを判断し、必要な場合は指定する -->
     <xsl:variable name="needWidth">
      <xsl:variable name="captionText">
       <xsl:text>  </xsl:text>
       <xsl:value-of disable-output-escaping="yes" select="substring-before($attachmentName, ':')"/>
       <xsl:text>  </xsl:text>
      </xsl:variable>
      <xsl:choose>
       <!-- 見出しが8文字未満の場合 -->
       <xsl:when test="string-length($captionText) &lt; 8">
        <!-- バイト数を取得 -->
        <xsl:variable name="captionByte">
         <xsl:call-template name="string-byte">
          <xsl:with-param name="string" select="$captionText"/>
          <xsl:with-param name="allByte" select="0"/>
         </xsl:call-template>
        </xsl:variable>
        <xsl:choose>
         <!-- バイト数が8byte未満の場合は幅を指定する -->
         <xsl:when test="$captionByte &lt; 8">
          <xsl:text>1</xsl:text>
         </xsl:when>
         <xsl:otherwise>
          <xsl:text>0</xsl:text>
         </xsl:otherwise>
        </xsl:choose>
       </xsl:when>
       <xsl:otherwise>
        <xsl:text>0</xsl:text>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:variable>
     <xsl:if test="$needWidth='1'">
      <xsl:text>width:32px;</xsl:text>
     </xsl:if>
    </xsl:attribute>
    <xsl:element name="font">
     <xsl:attribute name="color"><xsl:text>black</xsl:text></xsl:attribute>
     <xsl:attribute name="style">
      <xsl:text>position:relative;top:32px</xsl:text>
      <xsl:text>;font-size:9pt;font-family:</xsl:text><xsl:value-of select="$SansSerifFamily"/><xsl:text>;</xsl:text>
     </xsl:attribute>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
     <xsl:value-of select="substring-before($attachmentName, ':')"/>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
    </xsl:element>
   </xsl:element>

  <xsl:text disable-output-escaping='yes'>&lt;/a></xsl:text>

  <xsl:call-template name="OutputOutsideAttachment">
   <xsl:with-param name="list" select="substring-after($list, $v_var)"/>
  </xsl:call-template>
 </xsl:if>
</xsl:template>

<!--
**********************************************************************
CSS
********************************************************************** -->
<xsl:template name="css-block">
  <xsl:text disable-output-escaping="yes"><![CDATA[
   .richtable{border-collapse:collapse;empty-cells:show;table-layout:fixed;}
   .tablecell{ padding:0px;overflow:hidden; }
   .grid{layout-grid-line : 0px;}

   /* jcaptionを利用して画像にキャプションを付与する際のスタイル */
   span.caption p{
    padding:0px 8px;
    font-color:black;
    font-size:9pt;
    text-align:center;
   }

   /* Safari対応 キャプションと回り込みの文字が重ならないようにする */
   @media screen and (-webkit-min-device-pixel-ratio:0){
    span.caption{
     margin-bottom:12px;
    }
   }

  ]]></xsl:text>
</xsl:template>

<!-- ↓↓↓各項目のレイアウト↓↓↓ -->
<!--
**********************************************************************
段落書式
********************************************************************** -->
<xsl:template name="pardef"> 
 <xsl:variable name="rightmargin" select="@rightmargin"/>
 <xsl:variable name="firstlineleftmargin" select="@firstlineleftmargin"/>
 <xsl:variable name="align" select="@align"/>
 <xsl:variable name="linespacing" select="@linespacing"/>
 <xsl:variable name="spacebefore" select="@spacebefore"/>
 <xsl:variable name="spaceafter" select="@spaceafter"/>
 <xsl:variable name="list" select="@list"/>
 <xsl:variable name="newpage" select="@newpage"/>
 <xsl:variable name="id" select="@id"/>

 <xsl:variable name="rtitemname" select="ancestor::dxl:item/@name"/>

 <!-- @leftmarginが存在しない場合は固定値leftmargin=1inとする-->
 <xsl:variable name="leftmargin">
  <xsl:choose>
   <xsl:when test="count(@leftmargin)>0"><xsl:value-of select="@leftmargin"/></xsl:when>
   <xsl:when test="ancestor::dxl:tablecell">0in</xsl:when>
   <xsl:otherwise>1in</xsl:otherwise>
  </xsl:choose>
 </xsl:variable>

	<xsl:text>
		.</xsl:text><xsl:value-of select="$rtitemname"/><xsl:text>class</xsl:text>
		<xsl:value-of select="@id"/>
		<xsl:text>{</xsl:text>

<!-- 左マージン-->
	<xsl:text>
				padding-left:</xsl:text>
		<xsl:value-of select="$leftmargin"/><xsl:text>;</xsl:text>

<!-- 右マージン-->
		<xsl:if test="$rightmargin!=''">
			<xsl:choose>
				<xsl:when test="substring($rightmargin,string-length($rightmargin),1)='%'">
					<xsl:text>
				margin-right:</xsl:text>
					<xsl:value-of select="100-number(substring-before($rightmargin,'%'))"/>
					<xsl:text>%;</xsl:text>
				</xsl:when>
				<xsl:otherwise>
					<xsl:choose>
						<xsl:when test="substring($leftmargin,string-length($leftmargin),1)='%'">
						</xsl:when>
						<xsl:otherwise>
							<xsl:text>
				width:</xsl:text>
							<xsl:value-of select="number(substring-before($rightmargin,'in'))-number(substring-before($leftmargin,'in'))"/>
							<xsl:text>in;</xsl:text>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:if>

<!-- インデント -->
		<xsl:if test="$firstlineleftmargin!=''">
		 <xsl:choose>
			<xsl:when test="count(ancestor::dxl:tablecell) &gt; 0 and substring($leftmargin,string-length($leftmargin),1)='%'">
			<xsl:text>
				text-indent:</xsl:text>
			<xsl:variable name="textindent" select="number(substring-before($firstlineleftmargin,'%'))-number(substring-before($leftmargin,'%'))"/>
			<xsl:variable name="tableColumnWidth">
			 <xsl:variable name="tableColumn" select="count(ancestor::dxl:tablecell/preceding-sibling::dxl:tablecell) + 1"/>
			 <xsl:value-of select="ancestor::dxl:table[1]/dxl:tablecolumn[$tableColumn]/@width"/>
			</xsl:variable>
			<xsl:choose>
			 <xsl:when test="contains($tableColumnWidth, 'in')">
			  <xsl:value-of select="( $textindent  div 100 ) * number(substring-before($tableColumnWidth, 'in'))" />
			  <xsl:text>in;</xsl:text>
			 </xsl:when>
			 <xsl:otherwise>
			  <xsl:value-of select="$textindent" />
			  <xsl:text>%;</xsl:text>
			 </xsl:otherwise>
			</xsl:choose>
			</xsl:when>
			<xsl:when test="substring($leftmargin,string-length($leftmargin),1)='%'">
			<xsl:text>
				text-indent:</xsl:text>
			<xsl:value-of select="number(substring-before($firstlineleftmargin,'%'))-number(substring-before($leftmargin,'%'))"/>
			<xsl:text>%;</xsl:text>
			</xsl:when>
			<xsl:otherwise>
			<xsl:text>
				text-indent:</xsl:text>
			<xsl:value-of select="number(substring-before($firstlineleftmargin,'in'))-number(substring-before($leftmargin,'in'))"/>
			<xsl:text>in;</xsl:text>
			</xsl:otherwise>
		 </xsl:choose>
		</xsl:if>

<!-- 行間 -->	
 <xsl:choose>
  <xsl:when test="$linespacing!=''">
   <xsl:text>
				line-height:</xsl:text>
		<xsl:value-of select="$linespacing"/>
		<xsl:text>;</xsl:text>
  </xsl:when>
  <xsl:otherwise>
   <xsl:text>
				line-height:normal;</xsl:text>
  </xsl:otherwise>
 </xsl:choose>


<!-- 文字揃え -->	
 <xsl:choose>
  <xsl:when test="$align!=''">
   <xsl:text>
				text-align:</xsl:text><xsl:value-of select="$align"/><xsl:text>;</xsl:text>
  </xsl:when>
  <xsl:otherwise>
   <xsl:text>
				text-align:left;</xsl:text>
  </xsl:otherwise>
 </xsl:choose>

<!-- 改ページ -->
 <xsl:choose>
  <xsl:when test="$newpage='true'">
   <xsl:text>
				page-break-before: always;</xsl:text>
  </xsl:when>
  <xsl:otherwise>
  </xsl:otherwise>
 </xsl:choose>

<!-- 段落非表示 -->
 <xsl:if test="contains(@hide, 'read') or contains(@hide, 'notes')">
  <xsl:text>
				display:none;</xsl:text>
 </xsl:if>

<xsl:text>
			}
</xsl:text>
</xsl:template> 


<!--
**********************************************************************

リッチテキスト内のエレメント用テンプレート

********************************************************************** -->
<!--
**********************************************************************
item
********************************************************************** -->
<xsl:template match="dxl:item">
 <!--<xsl:apply-templates/>-->
 <xsl:comment>
   <xsl:value-of select="."/>
</xsl:comment>
</xsl:template>

  <!--
**********************************************************************
読者・作成者・名前フィールド
********************************************************************** -->
<xsl:template name="formatName">
 <xsl:param name="text"/>
 <xsl:call-template name="SubstringReplace">
  <xsl:with-param name="text"> 
   <xsl:call-template name="SubstringReplace">
    <xsl:with-param name="text"> 
     <xsl:call-template name="SubstringReplace">
      <xsl:with-param name="text" select="$text"/>
      <xsl:with-param name="replace" select="'CN='"/>
      <xsl:with-param name="by" select="''"/>
     </xsl:call-template>
    </xsl:with-param>
    <xsl:with-param name="replace" select="'OU='"/>
    <xsl:with-param name="by" select="''"/>
   </xsl:call-template>
  </xsl:with-param>
  <xsl:with-param name="replace" select="'O='"/>
  <xsl:with-param name="by" select="''"/>
 </xsl:call-template>
</xsl:template>

<!--
**********************************************************************
text
********************************************************************** -->
<xsl:template match="dxl:text"> 
 <xsl:apply-templates/>
</xsl:template> 

<!--
**********************************************************************
textlist
********************************************************************** -->
<xsl:template match="dxl:textlist">
 <xsl:for-each select ="dxl:text">
  <xsl:apply-templates/>
  <xsl:element name="br"/>
 </xsl:for-each>
</xsl:template>

<!--
**********************************************************************
section
********************************************************************** -->
<xsl:template match="dxl:section">
 <xsl:variable name="rtitemname" select="ancestor::dxl:item/@name"/>
 <xsl:variable name="borderstyle" select="dxl:sectiontitle/@borderstyle"/>
 <xsl:variable name="bordercolor" select="dxl:sectiontitle/@color"/>
 <xsl:variable name="def" select="dxl:sectiontitle/@pardef"/>
 <xsl:variable name="pardef" select="preceding::dxl:pardef[@id=$def]"/>
 <xsl:variable name="align" select="$pardef/@align"/>
 <xsl:variable name="firstlineleftmargin" select="$pardef/@firstlineleftmargin"/>
 <xsl:variable name="onread" select="@onread"/>
 <xsl:variable name="expanded" select="@expanded"/>
 <xsl:variable name="leftmargin" select="$pardef/@leftmargin"/>
 <xsl:variable name="gid" select="generate-id()"/>

 <!--sectionが連続する場合は行間がないので、強制的に段落を追加する-->
 <xsl:if test="name(preceding-sibling::*[1])='section'">
  <xsl:element name="p">
   <xsl:attribute name="style"><xsl:text>font-size:10pt;</xsl:text></xsl:attribute>
   <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
  </xsl:element>
 </xsl:if> 

 <xsl:for-each select="dxl:sectiontitle">
  <xsl:element name="div">
   <xsl:attribute name="class">
    <xsl:value-of select="$rtitemname"/><xsl:text>class</xsl:text><xsl:value-of select="$def"/>
   </xsl:attribute>

   <xsl:attribute name="style">
   <!-- セクションタイトルの場合はアウトデント設定がある場合は、矩形線がずれるので設定を変更する。-->
    <xsl:choose>
     <xsl:when test="$firstlineleftmargin!=''">
      <xsl:text>padding-left:</xsl:text>
      <xsl:choose>
       <xsl:when test="contains($firstlineleftmargin, 'in') or contains($firstlineleftmargin, '%')">
        <xsl:value-of select="$firstlineleftmargin"/>
       </xsl:when>
       <xsl:otherwise>
        <xsl:value-of select="number($firstlineleftmargin)"/>
        <xsl:text>in</xsl:text>
       </xsl:otherwise>
      </xsl:choose>
      <xsl:text>;text-indent:0in;</xsl:text>
     </xsl:when>
     <xsl:when test="string($leftmargin)=''">
      <!-- 表外の場合のみ出力する -->
      <xsl:if test="not(ancestor::dxl:tablecell)">
       <xsl:text>padding-left:0.75in;</xsl:text>
      </xsl:if>
     </xsl:when>
    </xsl:choose>
   </xsl:attribute>

   <xsl:element name="div">
    <xsl:attribute name="onclick">
     <xsl:text>section_expand('</xsl:text>
     <xsl:value-of select="$gid"/>
     <xsl:text>')</xsl:text>
    </xsl:attribute>
    <xsl:attribute name="style">
     <xsl:text>cursor:pointer;</xsl:text>
     <xsl:text>margin-left:0px;</xsl:text>
     <xsl:text>padding-left:20px;</xsl:text>
  
     <xsl:if test="@borderstyle='twoline' 
                or @borderstyle='triple'
                or @borderstyle='double'
                or @borderstyle='single'
                or @borderstyle='shadow'
                or count(@borderstyle)=0">
  
      <xsl:choose>
       <xsl:when test="$onread='collapse'">
        <xsl:text>background:url(../../domino/section_r.gif) no-repeat;zoom:1;</xsl:text>
       </xsl:when>
       <xsl:when test="$onread='expand'">
        <xsl:text>background:url(../../domino/section_d.gif) no-repeat;zoom:1;</xsl:text>
       </xsl:when>
       <xsl:when test="$expanded='true'">
        <xsl:text>background:url(../../domino/section_d.gif) no-repeat;zoom:1;</xsl:text>
       </xsl:when>
       <xsl:otherwise>
        <xsl:text>background:url(../../domino/section_r.gif) no-repeat;zoom:1;</xsl:text>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:if>
    </xsl:attribute>
  
    <xsl:element name="p">
     <xsl:attribute name="style">
      <xsl:text>text-indent:0in;</xsl:text>
      <xsl:choose>
       <xsl:when test="@borderstyle='shadow'">
        <xsl:text>border-top:solid 1px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>border-left:solid 1px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>border-right:solid 2px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>border-bottom:solid 2px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='single'">
        <xsl:text>border-bottom:solid 1px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='double'">
        <xsl:text>border-bottom:solid 2px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='triple'">
        <xsl:text>border-bottom:solid 3px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='twoline'">
        <xsl:text>border-bottom:double 3px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='windowcaption'">
        <xsl:text>border:double 3px #AAAAAA;</xsl:text>
        <xsl:text>background-color:</xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='gradient'">
        <xsl:text>filter:progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=</xsl:text>
        <xsl:value-of select="@color"/><xsl:text>,endColorStr=#FFFFFF);</xsl:text>
        <xsl:text>background-image:-webkit-linear-gradient(left,</xsl:text><xsl:value-of select="@color"/><xsl:text> ,white);</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
        <xsl:text>padding-left:28px;</xsl:text>
        <xsl:text>width:100%;</xsl:text>
       </xsl:when>
       <xsl:when test="@borderstyle='tab' or @borderstyle='tabdiag'">
        <xsl:text>border-bottom:solid 3px </xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
        <xsl:text>text-align:left;</xsl:text>
       </xsl:when>
       <xsl:otherwise>
        <xsl:choose>
         <xsl:when test="$align!=''">
          <xsl:text>text-align:</xsl:text><xsl:value-of select="$align"/><xsl:text>;</xsl:text>
         </xsl:when>
         <xsl:otherwise>
          <xsl:text>text-align:left;</xsl:text>
         </xsl:otherwise>
        </xsl:choose>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:attribute>
  
     <!-- セクションのタイトル　-->
     <xsl:choose>
      <xsl:when test="@borderstyle='tab' or @borderstyle='tabdiag'">
       <xsl:element name="span">
        <xsl:attribute name="style">
         <xsl:text>background-color:</xsl:text><xsl:value-of select="@color"/><xsl:text>;</xsl:text>
         <xsl:if test="@borderstyle='tabdiag'"><xsl:text>padding-left:28px;padding-right:28px;</xsl:text></xsl:if>
         <xsl:if test="@borderstyle='tab'"><xsl:text>margin-left:5px;padding-left:3px;padding-right:3px;</xsl:text></xsl:if>
         <xsl:if test="count(child::dxl:font)=0"><xsl:text>font-size:10pt;</xsl:text></xsl:if>
        </xsl:attribute>
        <xsl:call-template name="runelement"/>
       </xsl:element>
      </xsl:when>
      <xsl:otherwise>
       <xsl:call-template name="runelement"/>
      </xsl:otherwise>
     </xsl:choose>

    </xsl:element>
   </xsl:element>
  </xsl:element>
 </xsl:for-each>

 <!-- セクションの中のコンテンツ　-->
 <xsl:element name="div">
  <xsl:attribute name="id"><xsl:value-of select="$gid"/></xsl:attribute>
  <xsl:choose>
   <xsl:when test="$onread='collapse'">
    <xsl:attribute name="collapse">true</xsl:attribute>
   </xsl:when>
   <xsl:when test="$onread='expand'">
   </xsl:when>
   <xsl:when test="$expanded='true'">
   </xsl:when>
   <xsl:otherwise>
    <xsl:attribute name="collapse">true</xsl:attribute>
   </xsl:otherwise>
  </xsl:choose>
  <xsl:apply-templates select="current()/*[position()>1]" />
 </xsl:element>

 <!-- セクションの下の線 -->
 <xsl:element name="div">
  <xsl:attribute name="class">
   <xsl:value-of select="$rtitemname"/><xsl:text>class</xsl:text>
   <xsl:value-of select="$def"/>
  </xsl:attribute>

  <!-- セクションタイトルの場合はアウトデント設定がある場合は、矩形線がずれるので設定を変更する。-->
  <xsl:if test="$firstlineleftmargin!=''">
   <xsl:attribute name="style">
    <xsl:choose>
     <xsl:when test="$firstlineleftmargin!=''">
      <xsl:text>padding-left:</xsl:text>
      <xsl:choose>
       <xsl:when test="contains($firstlineleftmargin, 'in') or contains($firstlineleftmargin, '%')">
        <xsl:value-of select="$firstlineleftmargin"/>
       </xsl:when>
       <xsl:otherwise>
        <xsl:value-of select="number($firstlineleftmargin)"/>
        <xsl:text>in</xsl:text>
       </xsl:otherwise>
      </xsl:choose>
      <xsl:text>;text-indent:0in;</xsl:text>
     </xsl:when>
     <xsl:when test="string($leftmargin)=''">
      <xsl:text>padding-left:1in;</xsl:text>
     </xsl:when>
    </xsl:choose>
   </xsl:attribute>
  </xsl:if>

  <xsl:element name="div">
   <xsl:attribute name="style"><xsl:text>padding-left:20px;</xsl:text></xsl:attribute>
   <xsl:element name="p">
    <xsl:attribute name="style">
     <xsl:choose>
      <xsl:when test="$borderstyle='single' or $borderstyle='shadow' or $borderstyle='windowcaption' or $borderstyle='gradient' or $borderstyle='tab' or $borderstyle='tabdiag'">
       <xsl:text>border-bottom:solid 1px </xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
      </xsl:when>
      <xsl:when test="$borderstyle='double'">
       <xsl:text>border-bottom:solid 2px </xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
      </xsl:when>
      <xsl:when test="$borderstyle='triple'">
       <xsl:text>border-bottom:solid 3px </xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
      </xsl:when>
      <xsl:when test="$borderstyle='twoline'">
       <xsl:text>border-bottom:double 3px </xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
      </xsl:when>
      <xsl:otherwise>
       <xsl:text>border:none;</xsl:text>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:attribute>
   </xsl:element>
  </xsl:element>
 </xsl:element>
</xsl:template>

<!--
**********************************************************************
richtext														
********************************************************************** -->
<xsl:template match="dxl:richtext">
<div class="richtext">
 <xsl:apply-templates/>
 <xsl:text> </xsl:text>
</div>
</xsl:template> 

<!--
**********************************************************************
pardef
********************************************************************** -->
<xsl:template match="dxl:pardef">
 <xsl:apply-templates/>
</xsl:template>

<!--
**********************************************************************
embeddedcontrol（埋め込みオブジェクト）
********************************************************************** -->
<xsl:template match="dxl:embeddedcontrol"> 
 <xsl:variable name="allowmultilines" select="@allowmultilines"/>
 <xsl:choose>
  <xsl:when test="$allowmultilines='false'">
		<xsl:element name="p">
    <xsl:attribute name="width"><xsl:value-of select="@width"/></xsl:attribute>
    <xsl:attribute name="height"><xsl:value-of select="@height"/></xsl:attribute>
    <xsl:attribute name="value"><xsl:apply-templates/></xsl:attribute>
		</xsl:element>
  </xsl:when>
  <xsl:otherwise>
   <xsl:apply-templates/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
button
********************************************************************** -->
<xsl:template match="dxl:button"> 
<!--
 <xsl:variable name="allowmultilines" select="@allowmultilines"/>
		<xsl:element name="button">
  <xsl:attribute name="width"><xsl:value-of select="@width"/></xsl:attribute>
  <xsl:attribute name="height"><xsl:value-of select="@height"/></xsl:attribute>
  <xsl:apply-templates/>
	</xsl:element>
-->
</xsl:template>

<!--
**********************************************************************
compositedata
********************************************************************** -->
<xsl:template match="dxl:compositedata"> 
</xsl:template>

<!--
**********************************************************************
埋め込み設計要素
********************************************************************** -->
<!-- ビュー -->
<xsl:template match="dxl:embeddedview">
</xsl:template>
<!-- ナビゲータ -->
<xsl:template match="dxl:embeddednavigator">
</xsl:template>
<!-- アウトライン -->
<xsl:template match="dxl:embeddedoutline">
</xsl:template>
<!-- 日付ピッカー -->
<xsl:template match="dxl:embeddeddatepicker">
</xsl:template>
<!-- フォルダーペイン -->
<xsl:template match="dxl:embeddedfolderpane">
</xsl:template>
<!-- ナビゲータの呼び出し -->
<xsl:template match="dxl:imagemap">
 <xsl:apply-templates select="dxl:picture"/>
</xsl:template>

<!--
**********************************************************************
defsearch
********************************************************************** -->
<xsl:template name="defsearch">
 <!-- 自要素が属するitem要素の名前を取得 -->
 <xsl:variable name="itemName" select="ancestor::dxl:item/@name"/>
 <!-- 自要素からみて直前のdef属性を持つpar要素を取得 -->
 <xsl:variable name="searchnode" select="preceding::dxl:par[@def][1]"/>
 <xsl:choose>
  <!-- 直前のdef属性を持つpar要素が取得できた場合 -->
  <xsl:when test="$searchnode">
   <xsl:variable name="def" select="$searchnode/@def"/>
   <!-- 直前のdef属性を持つpar要素が属するitem要素の名前を取得 -->
   <xsl:variable name="searchItemName" select="$searchnode/ancestor::dxl:item/@name"/>
   <xsl:choose>
    <!-- 自要素が属するitem要素内のpar要素でない場合 -->
    <xsl:when test="$itemName!=$searchItemName">
     <!-- par要素が属するitem要素の名前とdef属性の値を連結して返す -->
     <xsl:value-of select="concat(concat($searchItemName, $v_var), $def)"/>
    </xsl:when>
    <xsl:otherwise><xsl:value-of select="$def"/></xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <!-- 直前のdef属性を持つpar要素が取得できなかった場合 -->
  <xsl:otherwise>
   <!-- 標準スタイルが適用されるような値を返す -->
   <xsl:value-of select="concat(concat('default', $v_var), '0')"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<xsl:template name="getDef">
 <xsl:param name="inputString"/>
 <xsl:choose>
  <xsl:when test="contains($inputString, $v_var)">
   <xsl:value-of select="substring-after($inputString, $v_var)"/>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of select="$inputString"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
par(段落)
********************************************************************** -->
<xsl:template match="dxl:par"> 
 <xsl:variable name="rtitemname" select="ancestor::dxl:item/@name"/>

 <!-- par要素にdef属性を持たない場合を考慮 -->
 <xsl:variable name="def">
  <xsl:choose>
   <xsl:when test="string-length(@def)=0">
    <xsl:call-template name="defsearch"/>
   </xsl:when>
   <xsl:otherwise><xsl:value-of select="@def"/></xsl:otherwise>
  </xsl:choose>
 </xsl:variable>
 <xsl:element name="div">
  <!-- スタイル呼び出し-->
  <xsl:attribute name="class">
   <xsl:choose>
    <xsl:when test="contains($def, $v_var)">
     <xsl:value-of select="substring-before($def, $v_var)"/><xsl:text>class</xsl:text><xsl:value-of select="substring-after($def, $v_var)"/>
    </xsl:when>
    <xsl:otherwise>
     <xsl:value-of select="$rtitemname"/><xsl:text>class</xsl:text><xsl:value-of select="$def"/>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:attribute>

  <!-- 内部の最大フォントサイズを取得する-->
  <xsl:variable name="maxfontsize">
   <xsl:choose>
    <xsl:when test="count(descendant::dxl:font/@size) &gt; 0">
     <xsl:for-each select="descendant::dxl:font/@size"> 
      <xsl:sort select="number(substring-before(.,'pt'))" order="descending" /> 
      <xsl:if test="position()=1"> 
       <xsl:value-of select="number(substring-before(.,'pt'))" />
      </xsl:if> 
     </xsl:for-each> 
    </xsl:when>
    <xsl:otherwise>10</xsl:otherwise>
   </xsl:choose>
  </xsl:variable>

  <xsl:variable name="defOnly">
   <xsl:call-template name="getDef">
    <xsl:with-param name="inputString" select="$def"/>
   </xsl:call-template>
  </xsl:variable>
  <xsl:variable name="pardef" select="preceding::dxl:pardef[@id=$defOnly]"/>
  <xsl:variable name="spacebefore" select="$pardef/@spacebefore"/>
  <xsl:variable name="spaceafter" select="$pardef/@spaceafter"/>
  <xsl:variable name="liststyle" select="$pardef/@list"/>

  <xsl:variable name="margintopsize">
   <xsl:choose>
    <xsl:when test="$spacebefore!=''">
     <xsl:value-of select="$maxfontsize*($spacebefore - 1)"/> 			
    </xsl:when>
    <xsl:otherwise>0</xsl:otherwise>
   </xsl:choose>
  </xsl:variable>

  <xsl:variable name="marginbottomsize">
   <xsl:choose>
    <xsl:when test="$spaceafter!=''">
     <xsl:value-of select="$maxfontsize*($spaceafter - 1)"/> 			
    </xsl:when>
    <xsl:otherwise>0</xsl:otherwise>
   </xsl:choose>
  </xsl:variable>

  <xsl:attribute name="style">
   <xsl:if test="boolean(number($spaceafter))">
    <xsl:text>margin-bottom:</xsl:text>
    <xsl:value-of select="$marginbottomsize"/>
    <xsl:text>pt;</xsl:text>
   </xsl:if>

   <xsl:if test="boolean(number($spacebefore))">
    <xsl:text>margin-top:</xsl:text>
    <xsl:value-of select="$margintopsize"/>
    <xsl:text>pt;</xsl:text>
   </xsl:if>

<!--
   <xsl:if test="boolean(number($spacebefore))">
    <xsl:text>margin-top:</xsl:text>
    <xsl:value-of select="$maxfontsize*($spacebefore - 1)"/>
    <xsl:text>pt;</xsl:text>
   </xsl:if>
-->

  </xsl:attribute>

  <xsl:choose>
<!--
   <xsl:when test="count(child::dxl:horizrule)>0">
    <xsl:element name="p"><xsl:apply-templates /></xsl:element>
   </xsl:when>
-->
   <xsl:when test="count(child::node())=0">
    <xsl:element name="font">
     <xsl:attribute name="style"><xsl:text>font-size:10pt;</xsl:text></xsl:attribute>
     <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#65279;')"/>
    </xsl:element>
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="p">
     <xsl:if test="$liststyle!='' and $liststyle!='none'">
      <xsl:element name="img">
       <xsl:attribute name="src">
        <xsl:text>../../domino/</xsl:text>
        <xsl:choose>
         <xsl:when test="$liststyle='bullet'"><xsl:text>bullet.gif</xsl:text></xsl:when>
         <xsl:when test="$liststyle='check'"><xsl:text>check.gif</xsl:text></xsl:when>
         <xsl:when test="$liststyle='uncheck'"><xsl:text>uncheck.gif</xsl:text></xsl:when>
         <xsl:when test="$liststyle='circle'"><xsl:text>circle.gif</xsl:text></xsl:when>
         <xsl:when test="$liststyle='square'"><xsl:text>square.gif</xsl:text></xsl:when>
         <xsl:otherwise><xsl:text>bullet.gif</xsl:text></xsl:otherwise>
        </xsl:choose>
       </xsl:attribute>
       <xsl:attribute name="style">
        <!-- Safari、Chromeではmargin-leftで画像を移動させても右余白ができないため、padding-rightを併用 -->
        <xsl:text>margin-left:-0.25in;padding-right:0.15in;</xsl:text>
       </xsl:attribute>
      </xsl:element>
     </xsl:if>
     <xsl:apply-templates />
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:element>
 <!-- picture要素のテンプレートにて付与したfloat属性をリセット -->
 <xsl:if test="dxl:picture/@align='left' or dxl:picture/@align='right' or dxl:picture/@align='around'">
   <xsl:element name="br">
     <xsl:attribute name="clear">
       <xsl:text>all</xsl:text>
     </xsl:attribute>
   </xsl:element>
 </xsl:if>
</xsl:template> 


<!--
**********************************************************************
table-width
********************************************************************** -->
<xsl:template name="getTableWidth">
    <xsl:param name="elem"/>
    <xsl:variable name="following" select="$elem/following-sibling::dxl:tablecolumn[1]"/>
    <xsl:variable name="next">
			<xsl:choose>
      <xsl:when test="name($following)='tablecolumn'">
        <xsl:call-template name="getTableWidth">
          <xsl:with-param name="elem" select="$following"/>
        </xsl:call-template>
			</xsl:when>
   		<xsl:otherwise>0</xsl:otherwise>
			</xsl:choose>
    </xsl:variable>
    <xsl:value-of select="number(substring-before($elem/@width, 'in')) + number($next)"/> 
  </xsl:template>

<!--
**********************************************************************
anchor
********************************************************************** -->
<xsl:template match="dxl:anchor"></xsl:template> 

<!--
**********************************************************************
databaselink
********************************************************************** -->
<xsl:template match="dxl:databaselink">
 <xsl:element name="a">
  <xsl:attribute name="href">
   <xsl:text>../../</xsl:text><xsl:value-of select="@database"/><xsl:text>/index.html</xsl:text>
  </xsl:attribute>
  <xsl:choose>
   <xsl:when test="string-length(descendant::text())!=0">
    <xsl:element name="span">
     <xsl:attribute name="style">
      <xsl:text>font-size:10pt;</xsl:text>
      <xsl:if test="@showborder='true'">
       <xsl:text>border:1px solid green;</xsl:text>
      </xsl:if>
     </xsl:attribute>
     <xsl:apply-templates />
    </xsl:element>
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="img">
     <xsl:attribute name="src"><xsl:text>../../domino/dblink.gif</xsl:text></xsl:attribute>
     <xsl:attribute name="style"><xsl:text>border-width:0px;</xsl:text></xsl:attribute>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:element>
</xsl:template> 

<!--
**********************************************************************
doclink
********************************************************************** -->
<xsl:template match="dxl:doclink">
 <xsl:element name="a">
  <xsl:attribute name="href">
   <xsl:text>../../</xsl:text><xsl:value-of select="@database"/><xsl:text>/document/</xsl:text><xsl:value-of select="@document"/><xsl:text>.html</xsl:text>
  </xsl:attribute>
  <xsl:choose>
   <xsl:when test="string-length(descendant::text())!=0">
    <xsl:element name="span">
     <xsl:attribute name="style">
      <xsl:text>font-size:10pt;</xsl:text>
      <xsl:if test="@showborder='true'">
       <xsl:text>border:1px solid green;</xsl:text>
      </xsl:if>
     </xsl:attribute>
     <xsl:apply-templates />
    </xsl:element>
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="img">
     <xsl:attribute name="src"><xsl:text>../../domino/doclink.gif</xsl:text></xsl:attribute>
     <xsl:attribute name="style"><xsl:text>border-width:0px;</xsl:text></xsl:attribute>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:element>
</xsl:template> 

<!--
**********************************************************************
viewlink
********************************************************************** -->
<xsl:template match="dxl:viewlink">
 <xsl:element name="a">
  <xsl:attribute name="href">
   <xsl:text>../../</xsl:text><xsl:value-of select="@database"/><xsl:text>/view/</xsl:text><xsl:value-of select="@view"/><xsl:text>.html</xsl:text>
  </xsl:attribute>
  <xsl:choose>
   <xsl:when test="string-length(descendant::text())!=0">
    <xsl:element name="span">
     <xsl:attribute name="style">
      <xsl:text>font-size:10pt;</xsl:text>
      <xsl:if test="@showborder='true'">
       <xsl:text>border:1px solid green;</xsl:text>
      </xsl:if>
     </xsl:attribute>
     <xsl:apply-templates />
    </xsl:element>
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="img">
     <xsl:attribute name="src"><xsl:text>../../domino/viewlink.gif</xsl:text></xsl:attribute>
     <xsl:attribute name="style"><xsl:text>border-width:0px;</xsl:text></xsl:attribute>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:element>
</xsl:template> 

<!--
**********************************************************************
urllink
********************************************************************** -->
<xsl:template match="dxl:urllink"> 
 <xsl:call-template name="createUrlLink">
  <xsl:with-param name="href" select="@href"/>
 </xsl:call-template>
</xsl:template> 

<xsl:template name="createUrlLink">
 <xsl:param name="href"/>
 <xsl:element name="a">
  <xsl:attribute name="href"><xsl:value-of select="$href"/></xsl:attribute>
  <xsl:apply-templates />
 </xsl:element>
</xsl:template>

<!--
**********************************************************************
region
********************************************************************** -->
<xsl:template match="dxl:region">
 <xsl:variable name="regionid" select="@regionid"/>
 <xsl:variable name="urllinkNode" select="preceding::dxl:urllink[@regionid=$regionid]"/>
 <xsl:choose>
  <!-- 複数行のホットスポット(URLリンク)の場合は、各行毎にa要素で囲む -->
  <xsl:when test="$urllinkNode">
   <xsl:call-template name="createUrlLink">
    <xsl:with-param name="href" select="$urllinkNode/@href"/>
   </xsl:call-template>
  </xsl:when>
  <xsl:otherwise>
   <xsl:apply-templates />
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
文字修飾テンプレート
********************************************************************** -->
<xsl:template name="runelement">
<xsl:param name="innertext"/>

 <xsl:variable name="str" select="dxl:font/@size"/>
 <xsl:variable name="text" select="descendant::text()"/>
 <xsl:variable name="highlight">
  <xsl:choose>
   <xsl:when test='count(dxl:font/@highlight)>0'>
    <xsl:value-of select="dxl:font/@highlight"/>
   </xsl:when>
   <xsl:when test='count(@highlight)>0'>
    <xsl:value-of select="@highlight"/>
   </xsl:when>
  </xsl:choose>
 </xsl:variable>


<xsl:choose>
 <xsl:when test="string-length($text)=0 and string-length($innertext)=0">
  <xsl:if test="string-length(parent::*//text())=0">
   <xsl:element name="font">
    <xsl:attribute name="style">
     <xsl:choose>
     <xsl:when test="string-length($str)>0">
      <xsl:text>font-size:</xsl:text><xsl:value-of select="$str"/><xsl:text>;</xsl:text>
     </xsl:when>	  
    	<xsl:otherwise>
    	 <xsl:text>font-size:10pt;</xsl:text>
    	</xsl:otherwise>
    </xsl:choose>
    </xsl:attribute>
    <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
   </xsl:element>
  </xsl:if>
 </xsl:when>
 <xsl:otherwise>

  <xsl:element name="font">
   <xsl:attribute name="face">
   <xsl:choose>
		  <xsl:when test="dxl:font/@name='Default Sans Serif'">
		   <xsl:value-of select="$SansSerifFamily"/>
		  </xsl:when>
		  <xsl:when test="dxl:font/@name='Default Serif'">
		   <xsl:value-of select="$SerifFamily"/>
		  </xsl:when>
		  <xsl:when test="dxl:font/@name='Default Monospace'">
		   <xsl:value-of select="$MonospaceFamily"/>
		  </xsl:when>
		  <xsl:when test="dxl:font/@name!='Small Fonts'">
		    <xsl:value-of select="dxl:font/@name"/>
		  </xsl:when>
    	<xsl:otherwise>
		   <xsl:value-of select="$SansSerifFamily"/>
			</xsl:otherwise>
   	</xsl:choose>
   </xsl:attribute>

  <xsl:attribute name="style">
   <xsl:if test="$highlight='blue'"><xsl:text>background-color:lightblue;</xsl:text></xsl:if>
   <xsl:if test="$highlight='pink'"><xsl:text>background-color:lightpink;</xsl:text></xsl:if>
   <xsl:if test="$highlight='yellow'"><xsl:text>background-color:khaki;</xsl:text></xsl:if>

   <xsl:text>white-space:normal;</xsl:text>
   <xsl:choose>
    <xsl:when test="string-length($str)>0">
     <xsl:text>font-size:</xsl:text><xsl:value-of select="$str"/><xsl:text>;</xsl:text>
    </xsl:when>	
    <xsl:when test="dxl:font">
     <xsl:text>font-size:10pt;</xsl:text>
    </xsl:when>	
    <xsl:when test="string-length($text)>0">
     <xsl:text>font-size:10pt;</xsl:text>
    </xsl:when>	
    <xsl:when test="string-length($str)=0">
     <xsl:text>font-size:10pt;</xsl:text>
    </xsl:when>	
    <xsl:otherwise></xsl:otherwise>
   </xsl:choose>
  </xsl:attribute>

  <xsl:attribute name="color">
   <xsl:choose>
    <xsl:when test="dxl:font/@color='system'">
     <xsl:choose>
      <!-- URLリンクの場合は青字にする -->
      <xsl:when test="ancestor::dxl:urllink">
       <xsl:text>blue</xsl:text>
      </xsl:when>
      <!-- 複数行のURLリンクの場合に対応 -->
      <xsl:when test="ancestor::dxl:region">
       <xsl:variable name="regionid" select="ancestor::dxl:region/@regionid"/>
       <xsl:choose>
        <xsl:when test="preceding::dxl:urllink[@regionid=$regionid]">
         <xsl:text>blue</xsl:text>
        </xsl:when>
        <xsl:otherwise>
         <xsl:text>black</xsl:text>
        </xsl:otherwise>
       </xsl:choose>
      </xsl:when>
      <xsl:otherwise>
       <xsl:text>black</xsl:text>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:when>
    <xsl:when test="dxl:font/@color!=''">
     <xsl:value-of select="dxl:font/@color"/>
    </xsl:when>
    <xsl:otherwise>black</xsl:otherwise>
   </xsl:choose>
  </xsl:attribute>
  <xsl:if test="dxl:font">
   <xsl:if test="contains(dxl:font/@style,'bold')">
    <xsl:text disable-output-escaping='yes'>&lt;b></xsl:text>  
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'italic')">
    <xsl:text disable-output-escaping='yes'>&lt;i></xsl:text>  
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'underline')">
    <xsl:text disable-output-escaping='yes'>&lt;u></xsl:text>  
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'strikethrough')">
    <xsl:text disable-output-escaping='yes'>&lt;s></xsl:text>
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'superscript')">
    <xsl:variable name="size" select="number(substring-before($str,'pt')) div 2"/>
    <xsl:text disable-output-escaping='yes'>&lt;Sup style="font-size:</xsl:text><xsl:value-of select="$size"/><xsl:text disable-output-escaping='yes'>pt;vertical-align:top"></xsl:text>
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'subscript')">
    <xsl:variable name="size" select="number(substring-before($str,'pt')) div 2"/>
    <xsl:text disable-output-escaping='yes'>&lt;Sub style="font-size:</xsl:text><xsl:value-of select="$size"/><xsl:text disable-output-escaping='yes'>pt;vertical-align:sub"></xsl:text>
   </xsl:if>
  </xsl:if>

	<xsl:choose>
    <xsl:when test="string-length($innertext)!=0">
    	<xsl:value-of select="$innertext"/>
    </xsl:when>
		<xsl:otherwise>
	    <xsl:apply-templates />
		</xsl:otherwise>
	</xsl:choose>


  <xsl:if test="dxl:font">
   <xsl:if test="contains(dxl:font/@style,'subscript')">
    <xsl:text disable-output-escaping='yes'>&lt;/Sub></xsl:text>
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'superscript')">
    <xsl:text disable-output-escaping='yes'>&lt;/Sup></xsl:text>
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'strikethrough')">
    <xsl:text disable-output-escaping='yes'>&lt;/s></xsl:text>
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'underline')">
    <xsl:text disable-output-escaping='yes'>&lt;/u></xsl:text>  
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'italic')">
    <xsl:text disable-output-escaping='yes'>&lt;/i></xsl:text>  
   </xsl:if>
   <xsl:if test="contains(dxl:font/@style,'bold')">
    <xsl:text disable-output-escaping='yes'>&lt;/b></xsl:text>  
   </xsl:if>
  </xsl:if>

  </xsl:element>
 </xsl:otherwise>
</xsl:choose>
</xsl:template> 

<!--
**********************************************************************
run
********************************************************************** -->
<xsl:template match="dxl:run">
 <xsl:choose>
  <xsl:when test="name(following-sibling::dxl:*[1])='horizrule' and string-length(child::text())=0"></xsl:when>
  <xsl:when test="name(preceding-sibling::dxl:*[1])='horizrule' and string-length(child::text())=0"></xsl:when>
  <xsl:otherwise>
   <xsl:call-template name="runelement"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
attachmentref
********************************************************************** -->
<xsl:template match="dxl:attachmentref">
 <xsl:variable name="name" select="@name"/>
 <xsl:variable name="dname" select="@displayname"/>

 <xsl:variable name="fileName">
  <xsl:if test="$name=$dname"><xsl:value-of disable-output-escaping='yes' select="$dname"/></xsl:if>
  <xsl:if test="$name!=$dname"><xsl:value-of disable-output-escaping='yes' select="$name"/>_<xsl:value-of disable-output-escaping='yes' select="$dname"/></xsl:if>
 </xsl:variable>

 <xsl:choose>
  <!--
   変換用スタイルシート生成の場合、添付ファイル名に日本語が含まれていると
   変換処理時にURLエンコードされてしまうため、xsl:text要素として出力する
  -->
  <xsl:when test="$CreateMode='xsl'">
   <xsl:element name="xsl:text">
    <xsl:attribute name="disable-output-escaping">
     <xsl:text>yes</xsl:text>
    </xsl:attribute>
    <xsl:text>&lt;a style='text-decoration:none;' target='_blank' href="</xsl:text>
   </xsl:element>
   <xsl:element name="xsl:text">
    <xsl:text>./form_</xsl:text>
   </xsl:element>
   <xsl:element name="xsl:value-of">
    <xsl:attribute name="select">
     <xsl:text>$formUnid</xsl:text>
    </xsl:attribute>
   </xsl:element>
   <xsl:element name="xsl:text">
    <xsl:text>/</xsl:text>
    <xsl:value-of select="$fileName"/>
   </xsl:element>
   <xsl:element name="xsl:text">
    <xsl:attribute name="disable-output-escaping">
     <xsl:text>yes</xsl:text>
    </xsl:attribute>
    <xsl:text disable-output-escaping='yes'>"></xsl:text>
   </xsl:element>
  </xsl:when>
  <!-- 変換処理実行の場合 -->
  <xsl:otherwise>
   <xsl:text disable-output-escaping='yes'>&lt;a style='text-decoration:none;' target='_blank' href="</xsl:text><xsl:value-of select='$imgsrc'/><xsl:value-of select="$fileName"/>
   <xsl:text disable-output-escaping='yes'>"></xsl:text>
  </xsl:otherwise>
 </xsl:choose>

 <xsl:apply-templates select="dxl:picture"/>
 <!-- 見出しが設定されている場合 -->
 <xsl:if test="@caption">
  <xsl:element name="font">
   <xsl:attribute name="color"><xsl:text>black</xsl:text></xsl:attribute>
   <xsl:attribute name="style">
    <xsl:text>font-size:9pt;font-family:</xsl:text><xsl:value-of select="$SansSerifFamily"/><xsl:text>;</xsl:text>
   </xsl:attribute>
   <xsl:apply-templates select="@caption"/>
  </xsl:element>
 </xsl:if>

 <xsl:choose>
  <xsl:when test="$CreateMode='xsl'">
   <xsl:element name="xsl:text">
    <xsl:attribute name="disable-output-escaping">
     <xsl:text>yes</xsl:text>
    </xsl:attribute>
    <xsl:text>&lt;/a></xsl:text>
   </xsl:element>
  </xsl:when>
  <xsl:otherwise>
   <xsl:text disable-output-escaping='yes'>&lt;/a></xsl:text>
  </xsl:otherwise>
 </xsl:choose>

</xsl:template>


<!--
**********************************************************************
caption
********************************************************************** -->
<xsl:template match="dxl:caption">
 <xsl:apply-templates/>
</xsl:template>


<!--
**********************************************************************
picture
********************************************************************** -->
<xsl:template match="dxl:picture">
 <xsl:variable name="imgnum">
  <xsl:number level="any" count="dxl:picture"/>
 </xsl:variable>

 <xsl:choose>
  <!-- 添付ファイルのアイコン画像の場合 -->
  <xsl:when test="parent::dxl:attachmentref">
   <!-- 画像に見出しを付けるため、span要素の背景画像として出力する -->
   <xsl:text disable-output-escaping="yes">
&lt;span</xsl:text>
    <xsl:choose>
     <xsl:when test="$CreateMode='xsl'">
      <xsl:text disable-output-escaping="yes">>
&lt;xsl:attribute name="style">
&lt;xsl:text></xsl:text>
     </xsl:when>
     <xsl:otherwise>
      <xsl:text disable-output-escaping="yes"> style="</xsl:text>
     </xsl:otherwise>
    </xsl:choose>

    <xsl:text>display:inline-block;text-indent:0in;</xsl:text>
    <xsl:choose>
     <xsl:when test="$CreateMode='xsl'">
      <xsl:text>form_</xsl:text>
      <xsl:text disable-output-escaping="yes">&lt;/xsl:text>
</xsl:text>
      <xsl:element name="xsl:value-of">
       <xsl:attribute name="select"><xsl:text>$formUnid</xsl:text></xsl:attribute>
      </xsl:element>
      <xsl:text disable-output-escaping="yes">
&lt;xsl:text></xsl:text>
     </xsl:when>
     <xsl:otherwise>
      <xsl:if test="count(dxl:imageref/@name)>0">
        <xsl:text>background: url(</xsl:text><xsl:value-of select="dxl:imageref/@name"/> 
    </xsl:if>  
    </xsl:otherwise>
    </xsl:choose>
     <xsl:text>) no-repeat top center;</xsl:text>
    <xsl:text>text-align:center;height:</xsl:text>
    <xsl:choose>
     <!-- picture要素の見出しが設定されている場合、見出し分を加えて画像の高さを設定 -->
     <xsl:when test="count(dxl:caption)!=0">
      <xsl:value-of select="number(substring-before(@height, 'px')) + 15"/><xsl:text>px;</xsl:text>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="@height"/><xsl:text>;</xsl:text>
     </xsl:otherwise>
    </xsl:choose>

    <!-- 幅を指定する必要があるかを判断し、必要な場合は指定する -->
    <xsl:variable name="needWidth">
     <xsl:choose>
      <!-- picture要素の見出しが設定されている場合 -->
      <xsl:when test="count(dxl:caption)!=0">
       <xsl:variable name="captionText">
        <xsl:variable name="captionTextOrg">
         <xsl:apply-templates select="dxl:caption"/>
        </xsl:variable>
        <xsl:call-template name="SubstringReplace">
         <xsl:with-param name="text">
          <xsl:call-template name="SubstringReplace">
           <xsl:with-param name="text" select="$captionTextOrg"/>
           <xsl:with-param name="replace" select="concat($amp, '#160;')"/>
           <xsl:with-param name="by" select="' '"/>
          </xsl:call-template>
         </xsl:with-param>
         <xsl:with-param name="replace" select="concat($amp, 'amp;')"/>
         <xsl:with-param name="by" select="'&amp;'"/>
        </xsl:call-template>
       </xsl:variable>
       <xsl:choose>
        <!-- 見出しが8文字未満の場合 -->
        <xsl:when test="string-length($captionText) &lt; 8">
         <!-- バイト数を取得 -->
         <xsl:variable name="captionByte">
          <xsl:call-template name="string-byte">
           <xsl:with-param name="string" select="$captionText"/>
           <xsl:with-param name="allByte" select="0"/>
          </xsl:call-template>
         </xsl:variable>
         <xsl:choose>
          <!-- バイト数が8byte未満の場合は幅を指定する -->
          <xsl:when test="$captionByte &lt; 8">
           <xsl:text>1</xsl:text>
          </xsl:when>
          <xsl:otherwise>
           <xsl:text>0</xsl:text>
          </xsl:otherwise>
         </xsl:choose>
        </xsl:when>
        <xsl:otherwise>
         <xsl:text>0</xsl:text>
        </xsl:otherwise>
       </xsl:choose>
      </xsl:when>
      <!-- picture要素の見出しが設定されていない場合は幅を指定する -->
      <xsl:otherwise>
       <xsl:text>1</xsl:text>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:variable>
    <xsl:if test="$needWidth='1'">
     <xsl:text>width:</xsl:text><xsl:value-of select="@width"/><xsl:text>;</xsl:text>
    </xsl:if>
    <!-- 添付ファイルのアイコン画像の場合はマウスカーソルの形状を指型にする -->
    <xsl:if test="parent::dxl:attachmentref">
     <xsl:text>cursor:pointer;</xsl:text>
    </xsl:if>
    <!-- 画像の折り返しを設定する -->
    <xsl:choose>
     <xsl:when test="@align='left' or @align='around'">
      <xsl:text>float:left;</xsl:text>
     </xsl:when>
     <xsl:when test="@align='right'">
      <xsl:text>float:right;</xsl:text>
     </xsl:when>
     <xsl:when test="@align='top' or @align='middle'">
      <xsl:text>vertical-align:</xsl:text><xsl:value-of select="@align"/><xsl:text>;</xsl:text>
     </xsl:when>
     <!--
      行内でもっとも高さが大きいインライン要素に vertical-align:bottom; を指定すると、
      その要素の他の文字列等との位置関係は vertical-align:top; の場合と同じになる（IEの不具合）ため
      @align='bottom'の場合も@alignが存在しない場合と同じ扱いとする
     -->
     <xsl:otherwise></xsl:otherwise>
    </xsl:choose>

    <xsl:choose>
     <xsl:when test="$CreateMode='xsl'">
      <xsl:text disable-output-escaping="yes">&lt;/xsl:text>
&lt;/xsl:attribute></xsl:text>
     </xsl:when>
     <xsl:otherwise>
      <xsl:text disable-output-escaping="yes">"></xsl:text>
     </xsl:otherwise>
    </xsl:choose>

    <!-- picture要素の見出しが設定されている場合 -->
    <xsl:if test="count(dxl:caption)!=0">
     <xsl:element name="font">
      <xsl:attribute name="color"><xsl:text>black</xsl:text></xsl:attribute>
      <xsl:attribute name="style">
       <xsl:text>position:relative;top:</xsl:text>
       <xsl:value-of select="@height"/>
       <xsl:text>;font-size:9pt;font-family:</xsl:text><xsl:value-of select="$SansSerifFamily"/><xsl:text>;</xsl:text>
      </xsl:attribute>
      <xsl:apply-templates select="dxl:caption"/>
     </xsl:element>
    </xsl:if>

   <xsl:text disable-output-escaping="yes">
&lt;/span>
</xsl:text>

  </xsl:when>
  <!-- 添付ファイルのアイコン画像以外の場合 -->
  <xsl:otherwise>
   <xsl:choose>
    <!-- 境界線のスタイルが「画像」の場合 -->
    <xsl:when test="dxl:border/@style='picture'">
     <xsl:element name="span">
      <xsl:attribute name="style">
       <xsl:text>display:inline-block;background-color:white;border-style:solid;</xsl:text>
       <xsl:text>padding:</xsl:text>
       <xsl:value-of select="dxl:border/@insidewidth"/>
       <xsl:text>;</xsl:text>
       <xsl:text>border-width:</xsl:text>
       <xsl:value-of select="dxl:border/@width"/>
       <xsl:text>;</xsl:text>
       <xsl:text>border-color:</xsl:text>
       <xsl:value-of select="dxl:border/@color"/>
       <xsl:text>;</xsl:text>
      </xsl:attribute>
      <xsl:call-template name="outputImage">
       <xsl:with-param name="imgnum" select="$imgnum"/>
      </xsl:call-template>
     </xsl:element>
    </xsl:when>
    <!-- 境界線のスタイルが「画像」以外の場合 -->
    <xsl:otherwise>
     <xsl:call-template name="outputImage">
      <xsl:with-param name="imgnum" select="$imgnum"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template> 

<xsl:template name="outputImage">
 <xsl:param name="imgnum"/>

 <!-- img要素として出力 -->
 <xsl:element name="img">
  <xsl:attribute name="border">0</xsl:attribute>

  <!-- picture要素の見出しはtitle属性として出力し、jcaptionで表示させる（ただし、常に画像の下に表示） -->
  <xsl:if test="count(dxl:caption)!=0">
   <xsl:attribute name="class">
    <xsl:text>hasCaption</xsl:text>
   </xsl:attribute>
   <xsl:attribute name="title">
    <xsl:apply-templates select="dxl:caption"/>
   </xsl:attribute>
  </xsl:if>

  <xsl:attribute name="style">
   <!-- Safari対応 ブロック要素として認識されるようにする -->
   <xsl:text>display:inline-block;</xsl:text>
   <!-- 幅・高さを設定 -->
   <xsl:if test="@scaledwidth">
    <xsl:text>width:</xsl:text><xsl:value-of select="@scaledwidth"/><xsl:text>;</xsl:text>
   </xsl:if>
   <xsl:if test="@scaledheight">
    <xsl:text>height:</xsl:text><xsl:value-of select="@scaledheight"/><xsl:text>;</xsl:text>
   </xsl:if>
   <!-- 境界線のスタイルを設定 -->
   <xsl:if test="count(dxl:border/@style)!=0">
     <xsl:text>border-style:</xsl:text>
     <xsl:choose>
       <xsl:when test="dxl:border/@style='dot'">
         <xsl:text>dotted</xsl:text>
       </xsl:when>
       <xsl:when test="dxl:border/@style='dash'">
         <xsl:text>dashed</xsl:text>
       </xsl:when>
       <xsl:when test="dxl:border/@style='picture'">
         <xsl:text>solid</xsl:text>
       </xsl:when>
       <xsl:otherwise>
         <xsl:value-of select="dxl:border/@style"/>
       </xsl:otherwise>
     </xsl:choose>
     <xsl:text>;</xsl:text>
   </xsl:if>
   <xsl:if test="count(dxl:border/@width)!=0">
     <xsl:text>border-width:</xsl:text>
     <xsl:choose>
       <xsl:when test="dxl:border/@style='dot' or dxl:border/@style='dash' or dxl:border/@style='picture'">
         <xsl:text>1px</xsl:text>
       </xsl:when>
       <xsl:otherwise>
         <xsl:value-of select="dxl:border/@width"/>
       </xsl:otherwise>
     </xsl:choose>
     <xsl:text>;</xsl:text>
   </xsl:if>
   <xsl:if test="count(dxl:border/@color)!=0">
     <xsl:text>border-color:</xsl:text><xsl:value-of select="dxl:border/@color"/><xsl:text>;</xsl:text>
   </xsl:if>
   <!-- 画像の折り返しを設定する -->
   <xsl:choose>
    <xsl:when test="@align='left' or @align='around'">
     <xsl:text>float:left;</xsl:text>
    </xsl:when>
    <xsl:when test="@align='right'">
     <xsl:text>float:right;</xsl:text>
    </xsl:when>
    <xsl:when test="@align='top' or @align='middle'">
     <xsl:text>vertical-align:</xsl:text><xsl:value-of select="@align"/><xsl:text>;</xsl:text>
    </xsl:when>
    <!--
     行内でもっとも高さが大きいインライン要素に vertical-align:bottom; を指定すると、
     その要素の他の文字列等との位置関係は vertical-align:top; の場合と同じになる（IEの不具合）ため
     @align='bottom'の場合も@alignが存在しない場合と同じ扱いとする
    -->
    <xsl:otherwise></xsl:otherwise>
   </xsl:choose>
  </xsl:attribute>

  <xsl:choose>
   <xsl:when test="$CreateMode='xsl'">
    <xsl:element name="xsl:attribute">
     <xsl:attribute name="name"><xsl:text>src</xsl:text></xsl:attribute>
     <xsl:element name="xsl:text">
      <xsl:text>./form_</xsl:text>
     </xsl:element>
     <xsl:element name="xsl:value-of">
      <xsl:attribute name="select"><xsl:text>$formUnid</xsl:text></xsl:attribute>
     </xsl:element>
     <xsl:element name="xsl:text">
      <xsl:text>/</xsl:text>
      <xsl:value-of select="$image_fix"/><xsl:value-of select="$imgnum"/>.<xsl:apply-templates select="dxl:gif|dxl:jpeg|dxl:png|dxl:tif"/>
     </xsl:element>
    </xsl:element>
   </xsl:when>
   <xsl:otherwise>
    <xsl:if test="count(dxl:imageref)!=0">
        <xsl:attribute name="src"><xsl:value-of select="$imgsrc"/><xsl:value-of select="./dxl:imageref/@name"/>
        </xsl:attribute>
      </xsl:if>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:element>
</xsl:template>


<xsl:template match="dxl:gif|dxl:jpeg|dxl:png|dxl:tif">
 <xsl:value-of select="local-name()"/>
</xsl:template>


<!--
**********************************************************************
セル背景色取得
********************************************************************** -->
<xsl:template name="cell-backgroundcolor">
     <xsl:param name="bgcolor"/>
     <xsl:param name="cellbgcolor"/>
     <xsl:param name="colorstyle"/>
     <xsl:param name="altbgcolor"/>
     <xsl:param name="colnum"/>
     <xsl:param name="rownum"/>
     <xsl:param name="colmax"/>

      <!-- セル背景色 -->
       <xsl:choose>
        <xsl:when test="$cellbgcolor!=''">
         <xsl:value-of select="$cellbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='altrows' and ($rownum mod 2)!=0">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='altcolumns' and ($colnum mod 2)!=0">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='lefttop' and ($rownum &gt; 1 and $colnum &gt; 1)">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='left' and ($colnum &gt; 1)">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='righttop' and ($rownum &gt; 1 and $colnum &lt; $colmax)">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='right' and $colnum &lt; $colmax">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="$colorstyle='top' and $rownum &gt; 1">
         <xsl:value-of select="$altbgcolor"/>
        </xsl:when>
        <xsl:when test="string-length($cellbgcolor)=0">
         <xsl:value-of select="$bgcolor"/>
        </xsl:when>
        <xsl:otherwise>
         <xsl:value-of select="$cellbgcolor"/>
        </xsl:otherwise>
       </xsl:choose>
</xsl:template>

<!--
**********************************************************************
find-attvalue
********************************************************************** -->
<xsl:template name="find-attvalue">
<xsl:param name="nodelist"></xsl:param>
<xsl:param name="findstr"></xsl:param>
<xsl:variable name="check">
<xsl:for-each select="$nodelist">
	<xsl:if test="contains(.,$findstr)">1</xsl:if>
</xsl:for-each>
</xsl:variable>
<xsl:if test="contains($check,'1')">true</xsl:if>
</xsl:template>


<!--
**********************************************************************
table
********************************************************************** -->
<xsl:template match="dxl:table"> 
 <xsl:variable name="rtitemname" select="ancestor::dxl:item/@name"/>
 <xsl:variable name="gid" select="generate-id()"/>
 <xsl:variable name="def" select="preceding-sibling::dxl:par[1]/@def"/>
 <xsl:variable name="pardef" select="preceding::dxl:pardef[@id=$def]"/>
 <xsl:variable name="leftmargin" select="@leftmargin"/>
 <xsl:variable name="rightmargin" select="@rightmargin"/>
 <xsl:variable name="refwidth" select="@refwidth"/>
 <xsl:variable name="bgcolor" select="@bgcolor"/>
 <xsl:variable name="bordercolor" select="dxl:border/@color"/>
 <xsl:variable name="cellbordercolor" select="@cellbordercolor"/>
 <xsl:variable name="cellborderstyle" select="@cellborderstyle"/>
 <xsl:variable name="rowspacing" select="@rowspacing"/>
 <xsl:variable name="columnspacing" select="@columnspacing"/>
 <xsl:variable name="colmax" select="count(dxl:tablecolumn)"/>
 <xsl:variable name="align" select="@align"/>
 <xsl:variable name="linespacing" select="@linespacing"/>
 <xsl:variable name="spaceafter" select="@spaceafter"/>
 <xsl:variable name="spacebefore" select="@spacebefore"/>
 <xsl:variable name="newpage" select="@newpage"/>
 <xsl:variable name="colorstyle" select="@colorstyle"/>

 <xsl:variable name="altbgcolor">
  <xsl:call-template name="getColor">
   <xsl:with-param name="color" select="@altbgcolor"/>
  </xsl:call-template>
 </xsl:variable>

 <!-- 表の境界線スタイル情報 -->
 <xsl:variable name="borderstyle">
  <xsl:choose>
   <xsl:when test="dxl:border/@style='dot'">
    <xsl:text>dotted</xsl:text>
   </xsl:when>
   <xsl:when test="dxl:border/@style='dash'">
    <xsl:text>dashed</xsl:text>
   </xsl:when>
   <!-- 画像、イメージの場合は表の境界線はなし -->
   <xsl:when test="dxl:border/@style='picture' or dxl:border/@style='image'">
   </xsl:when>
   <xsl:otherwise>
    <xsl:value-of select="dxl:border/@style"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:variable>

 <!-- 表の境界線幅 -->
 <xsl:variable name="borderwidth">
  <!-- 表の境界線スタイルが、画像、イメージの場合は境界線幅なし -->
  <xsl:if test="not(dxl:border/@style='picture' or dxl:border/@style='image')">
   <xsl:value-of select="dxl:border/@width"/>
  </xsl:if>
 </xsl:variable>

 <!-- minrowheight -->
 <xsl:variable name="minrowheight">
  <xsl:if test="@minrowheight!=''">
   <xsl:variable name="str" select="@minrowheight"/>
   <xsl:variable name="len" select="string-length($str)"/>
   <xsl:variable name="htype" select="substring($str,$len,1)"/>
   <xsl:if test="$htype='n'">
    <xsl:variable name="height" select="substring($str,0,$len - 1)"/>
    <xsl:value-of select="$height * 96"/>
   </xsl:if>
   <xsl:if test="$htype='%'">
    <xsl:value-of select="$str"/>
   </xsl:if>
  </xsl:if>
 </xsl:variable>

 <xsl:element name="div">

  <!-- tableに@leftmarginが設定されていれば、その値で上書き-->
  <xsl:attribute name="style">
   <!-- 左余白が1in(2.54cm)の場合、table要素のleftmargin属性が出力されないため、強制的に1inを出力する -->
   <xsl:text>padding-left:</xsl:text>
   <xsl:choose>
    <xsl:when test="$leftmargin!=''"><xsl:value-of select="$leftmargin"/></xsl:when>
    <xsl:otherwise>1in</xsl:otherwise>
   </xsl:choose>
   <xsl:text>;</xsl:text>

   <xsl:if test="@rowdisplay='tabs' or @widthtype='fitmargins' or @widthtype='fitwindow'">
    <xsl:if test="$rightmargin!=''">
     <xsl:choose>
      <xsl:when test="substring($rightmargin,string-length($rightmargin),1)='%'">
       <xsl:text>margin-right:</xsl:text>
       <xsl:value-of select="100-number(substring-before($rightmargin,'%'))"/>
       <xsl:text>%;</xsl:text>
      </xsl:when>
      <xsl:otherwise>
       <xsl:if test="substring($leftmargin,string-length($leftmargin),1)!='%'">
        <xsl:text>width:</xsl:text>
        <xsl:value-of select="number(substring-before($rightmargin,'in'))"/>
        <xsl:text>in;</xsl:text>
       </xsl:if>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:if>
   </xsl:if>

  </xsl:attribute>

  <!-- tab表の場合 -->
  <xsl:variable name="tabsname"><xsl:value-of select="$gid"/>_tabs</xsl:variable>
  <xsl:if test="@rowdisplay='tabs'">
   <script>
    <xsl:text>$(function(){ $("#</xsl:text><xsl:value-of select="$tabsname"/><xsl:text>").tabs();});</xsl:text>
   </script>
   <div>
    <xsl:attribute name="id"><xsl:value-of select="$tabsname"/></xsl:attribute>
    <ul style="margin-left:-5px;margin-bottom:0px;-webkit-padding-start:1px;">
     <xsl:for-each select="dxl:tablerow">

      <xsl:variable name="tablabel">
       <xsl:choose>
        <xsl:when test="@tablabel"><xsl:value-of select="@tablabel"/></xsl:when>
        <xsl:otherwise><xsl:text>_</xsl:text></xsl:otherwise>
       </xsl:choose>
      </xsl:variable>

      <li>
       <xsl:attribute name="style">
        <xsl:text>background-color:</xsl:text>
        <xsl:call-template name="cell-backgroundcolor">
         <xsl:with-param name="bgcolor" select="$bgcolor"/>
         <xsl:with-param name="cellbgcolor">
          <xsl:call-template name="getColor">
           <xsl:with-param name="color" select="dxl:tablecell/@bgcolor"/>
          </xsl:call-template>
         </xsl:with-param>
         <xsl:with-param name="colorstyle" select="$colorstyle"/>
         <xsl:with-param name="altbgcolor" select="$altbgcolor"/>
         <xsl:with-param name="rownum" select="position()"/>
         <xsl:with-param name="colnum" select="1"/>
         <xsl:with-param name="colmax" select="$colmax"/>
        </xsl:call-template>
        <xsl:text>;</xsl:text>
       </xsl:attribute>
       <a>
        <xsl:attribute name="href">#<xsl:value-of select="$tabsname"/>_<xsl:value-of select="position()"/></xsl:attribute>
        <span>
         <xsl:choose>
          <xsl:when test="count(../dxl:tablerowstyle)>0">
           <xsl:for-each select="../dxl:tablerowstyle">
            <xsl:call-template name="runelement">
             <xsl:with-param  name="innertext"><xsl:value-of select="$tablabel"/></xsl:with-param>
            </xsl:call-template>
           </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
           <xsl:call-template name="runelement">
            <xsl:with-param  name="innertext"><xsl:value-of select="$tablabel"/></xsl:with-param>
           </xsl:call-template>
          </xsl:otherwise>
         </xsl:choose>
        </span>
       </a>
      </li>

     </xsl:for-each>
    </ul>
   </div>
  </xsl:if>

  <!--通常の表-->
  <xsl:element name="div">

   <!-- Safari対応 width:100%は直近のdiv要素へ付与しないとSafariで正しく認識されない -->
   <xsl:if test="@rowdisplay='tabs' or @widthtype='fitmargins' or @widthtype='fitwindow'">
    <xsl:attribute name="style">
     <xsl:text>width:100%;</xsl:text>
    </xsl:attribute>
   </xsl:if>

   <table>
    <xsl:attribute name="cellpadding">0</xsl:attribute>
    <xsl:attribute name="cellspacing">0</xsl:attribute>
    <xsl:attribute name="class">richtable</xsl:attribute>
    <xsl:attribute name="style">

     <!-- tab表の場合、行の下線が表示されるようにborder-collapse属性を上書き -->
     <xsl:if test="@rowdisplay='tabs'">
      <xsl:text>border-collapse:separate;</xsl:text>
     </xsl:if>

     <!-- 罫線スタイル -->
     <xsl:choose>
      <xsl:when test="$bordercolor!=''">
       <xsl:text>border-color:</xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
      </xsl:when>
      <xsl:otherwise>
       <xsl:text>border-color:black;</xsl:text>
      </xsl:otherwise>
     </xsl:choose>
 
     <xsl:if test="$borderstyle !=''">
      <xsl:text>border-style:</xsl:text><xsl:value-of select="$borderstyle"/><xsl:text>;</xsl:text>
     </xsl:if>
     <xsl:if test="$borderwidth !=''">
      <xsl:if test="$borderwidth !='0px'">
       <xsl:text>border-width:</xsl:text><xsl:value-of select="$borderwidth"/><xsl:text>;</xsl:text>
      </xsl:if>
     </xsl:if>
     <xsl:choose>
      <xsl:when test="@rowdisplay='tabs' or @widthtype='fitmargins' or @widthtype='fitwindow'">
       <xsl:variable name="check">
        <xsl:call-template name="find-attvalue">
         <xsl:with-param name="nodelist" select="dxl:tablecolumn/@width"/>
         <xsl:with-param name="findstr">%</xsl:with-param>
        </xsl:call-template>
       </xsl:variable>    
       <xsl:if test="$check='true'">
        <xsl:text>width:100%;</xsl:text>
       </xsl:if>
      </xsl:when>
      <xsl:otherwise>
       <xsl:choose>
        <xsl:when test="$colmax='1'">
         <xsl:text>width:</xsl:text><xsl:value-of select="dxl:tablecolumn[1]/@width"/><xsl:text>;</xsl:text>
        </xsl:when>
        <xsl:otherwise>
         <!-- Safari対応 固定幅の場合、表の幅も指定していないとSafariでは固定にならない -->
         <xsl:text>width:</xsl:text>
         <xsl:call-template name="getTableWidth">
          <xsl:with-param name="elem" select="dxl:tablecolumn"/>
         </xsl:call-template>
         <xsl:text>in;</xsl:text>
        </xsl:otherwise>
       </xsl:choose>
      </xsl:otherwise>
     </xsl:choose>

   <!-- 
    <xsl:if test="substring($leftmargin,string-length($leftmargin)-1,2)='in'">
	<xsl:text>padding-left:</xsl:text>
	<xsl:value-of select="number(substring-before($leftmargin,'in'))+1"/><xsl:text>in;</xsl:text>
	 </xsl:if>
	-->

    </xsl:attribute>

    <!-- 揃え -->
    <xsl:if test="@widthtype!=''">
     <xsl:attribute name="Align"></xsl:attribute>
    </xsl:if>
    <xsl:if test="@widthtype='fixedright'">
     <xsl:attribute name="Align">right</xsl:attribute>
    </xsl:if>
    <xsl:if test="@widthtype='fixedcenter'">
     <xsl:attribute name="Align">center</xsl:attribute>
    </xsl:if>
    <xsl:if test="@outsidewrap='true'">
     <xsl:attribute name="Align">left</xsl:attribute>
    </xsl:if>

    <xsl:for-each select="dxl:tablecolumn">
     <colgroup>
      <xsl:if test="position()!=$colmax or substring(@width,string-length(@width)-1,2)='in'">
       <xsl:attribute name="style">
        <xsl:text>width:</xsl:text><xsl:value-of select="@width"/><xsl:text>;</xsl:text>
       </xsl:attribute>
      </xsl:if>
     </colgroup>
    </xsl:for-each>

    <!-- CSSのrichtableクラスにてtable-layout属性をfixedにしたため、セル幅決定用のダミー行を追加する -->
    <tr>
     <xsl:for-each select="dxl:tablecolumn">
      <!-- 高さ指定が0pxの場合、印刷プレビューで高さのある空行となってしまうため、0%とする -->
      <td style="height:0%;"></td>
     </xsl:for-each>
    </tr>

    <xsl:for-each select ="dxl:tablerow">
     <xsl:variable name="rownum" select="position()"/>
     <tr>

      <!-- tab表の場合 -->
      <xsl:if test="../@rowdisplay='tabs'">
       <xsl:attribute name="id">
        <xsl:value-of select="$tabsname"/>_<xsl:value-of select="position()"/>
       </xsl:attribute>
      </xsl:if>

      <xsl:if test="$minrowheight!=''">
       <xsl:attribute name="style">
        <!-- table-layout:fixedの表のth, tr, td要素に対しては、IE6でもmin-heightが有効となる。 -->
        <xsl:text>min-height:</xsl:text><xsl:value-of select="$minrowheight"/><xsl:text>;</xsl:text>
        <!-- Safari対応 min-heightが有効とならない -->
        <xsl:text>height:</xsl:text><xsl:value-of select="$minrowheight"/><xsl:text>;</xsl:text>
       </xsl:attribute>
      </xsl:if>

      <xsl:for-each select ="dxl:tablecell">
       <xsl:variable name="i" select="position()"/> 
       <xsl:variable name="str" select="parent::*/parent::*/dxl:tablecolumn[$i]/@width"/>
       <xsl:variable name="len" select="string-length($str)"/>
       <xsl:variable name="wtype" select="substring($str,$len,1)"/>
       <xsl:variable name="cellcolorstyle" select="@colorstyle"/>

       <xsl:variable name="cellbgcolor">
        <xsl:call-template name="getColor">
         <xsl:with-param name="color" select="@bgcolor"/>
        </xsl:call-template>
       </xsl:variable>

       <xsl:variable name="cellaltbgcolor">
        <xsl:call-template name="getColor">
         <xsl:with-param name="color" select="@altbgcolor"/>
        </xsl:call-template>
       </xsl:variable>

       <td class="tablecell">
        <xsl:variable name="colnum" select="position()"/>

        <!-- 高さ揃え -->
        <xsl:attribute name="valign">
         <xsl:choose>
          <xsl:when test="@valign='center'">middle</xsl:when>
          <xsl:when test="@valign='bottom'">bottom</xsl:when>
          <xsl:otherwise>top</xsl:otherwise>
         </xsl:choose>
        </xsl:attribute>

        <!-- セル結合 -->
        <xsl:if test="@columnspan!=''">
         <xsl:attribute name="Colspan">
          <xsl:value-of select="@columnspan"/>
         </xsl:attribute>
        </xsl:if>
        <xsl:if test="@rowspan!=''">
         <xsl:attribute name="Rowspan">
          <xsl:value-of select="@rowspan"/>
         </xsl:attribute>
        </xsl:if>

        <!-- スタイル -->     
        <xsl:attribute name="style">

         <!-- セル背景色 -->
         <xsl:choose>
          <xsl:when test="$cellcolorstyle='vgradient' or $cellcolorstyle='hgradient'">
           <xsl:text>height:100%;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
           <xsl:text>background-color:</xsl:text>
           <xsl:call-template name="cell-backgroundcolor">
            <xsl:with-param name="bgcolor" select="$bgcolor"/>
            <xsl:with-param name="cellbgcolor" select="$cellbgcolor"/>
            <xsl:with-param name="colorstyle" select="$colorstyle"/>
            <xsl:with-param name="altbgcolor" select="$altbgcolor"/>
            <xsl:with-param name="colnum" select="$colnum"/>
            <xsl:with-param name="rownum" select="$rownum"/>
            <xsl:with-param name="colmax" select="$colmax"/>
           </xsl:call-template>
           <xsl:text>;</xsl:text>
           <xsl:if test="$rowspacing!=''">
            <xsl:text>padding-top:</xsl:text><xsl:value-of select="$rowspacing"/><xsl:text>;</xsl:text>
            <xsl:text>padding-bottom:</xsl:text><xsl:value-of select="$rowspacing"/><xsl:text>;</xsl:text>
           </xsl:if>
           <xsl:if test="$columnspacing!=''">
            <xsl:text>padding-left:</xsl:text><xsl:value-of select="$columnspacing"/><xsl:text>;</xsl:text>
            <xsl:text>padding-right:</xsl:text><xsl:value-of select="$columnspacing"/><xsl:text>;</xsl:text>
           </xsl:if>
          </xsl:otherwise>
         </xsl:choose>

         <xsl:choose>
          <!-- tab表の場合は固定 -->
          <xsl:when test="../../@rowdisplay='tabs'">
           <xsl:text>border-color:#97a5b0;</xsl:text>
          </xsl:when>
          <xsl:when test="$cellbordercolor!=''">
           <xsl:text>border-color:</xsl:text><xsl:value-of select="$cellbordercolor"/><xsl:text>;</xsl:text>
          </xsl:when>
          <xsl:when test="$bordercolor!=''">
           <xsl:text>border-color:</xsl:text><xsl:value-of select="$bordercolor"/><xsl:text>;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
           <xsl:text>border-color:black;</xsl:text>
          </xsl:otherwise>
         </xsl:choose>
         <xsl:choose>
          <!-- tab表の場合は固定 -->
          <xsl:when test="../../@rowdisplay='tabs'">
           <xsl:text>border-style:solid;</xsl:text>
          </xsl:when>
          <xsl:when test="$cellborderstyle!=''">
           <xsl:text>border-style:</xsl:text><xsl:value-of select="$cellborderstyle"/><xsl:text>;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
           <xsl:text>border-style:solid;</xsl:text>
          </xsl:otherwise>
         </xsl:choose>
         <xsl:choose>
          <!-- tab表の場合は固定 -->
          <xsl:when test="../../@rowdisplay='tabs'">
           <xsl:choose>
            <!-- border-collapse属性をseparateに設定しているため、2列目以降の左線は出力しない -->
            <xsl:when test="$colnum=1">
             <xsl:text>border-width:1px;</xsl:text>
            </xsl:when>
            <xsl:otherwise>
             <xsl:text>border-width:1px 1px 1px 0px;</xsl:text>
            </xsl:otherwise>
           </xsl:choose>
          </xsl:when>
          <xsl:when test="@borderwidth!=''">
           <xsl:text>border-width:</xsl:text><xsl:value-of select="@borderwidth"/><xsl:text>;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
           <xsl:text>border-width:1px;</xsl:text>
          </xsl:otherwise>
         </xsl:choose>
        </xsl:attribute>

        <!-- td要素のスタイルとしてグラデーションを指定すると印刷プレビューで表示されないためspan要素で囲む -->
        <xsl:choose>
         <xsl:when test="$cellcolorstyle='vgradient' or $cellcolorstyle='hgradient'">
          <xsl:element name="span">
           <xsl:attribute name="style">
            <xsl:text>display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=</xsl:text>
            <xsl:choose>
             <xsl:when test="$cellcolorstyle='vgradient'">
              <xsl:text>0</xsl:text>
             </xsl:when>
             <xsl:otherwise>
              <xsl:text>1</xsl:text>
             </xsl:otherwise>
            </xsl:choose>
            <xsl:text>,startColorStr=</xsl:text>
            <xsl:value-of select="$cellbgcolor"/><xsl:text>,endColorStr=</xsl:text>
            <xsl:value-of select="$cellaltbgcolor"/><xsl:text>);</xsl:text>
            <xsl:text>background-image:-webkit-linear-gradient(</xsl:text>
            <xsl:choose>
             <xsl:when test="$cellcolorstyle='vgradient'">
              <xsl:text>top,</xsl:text>
             </xsl:when>
             <xsl:otherwise>
              <xsl:text>left,</xsl:text>
             </xsl:otherwise>
            </xsl:choose>
            <xsl:value-of select="$cellbgcolor"/><xsl:text>,</xsl:text><xsl:value-of select="$cellaltbgcolor"/><xsl:text>);</xsl:text>
           </xsl:attribute>
           <xsl:choose>
            <xsl:when test="$rowspacing!='' or $columnspacing!=''">
             <xsl:element name="div">
              <xsl:attribute name="style">
               <xsl:if test="$rowspacing!=''">
                <xsl:text>margin-top:</xsl:text><xsl:value-of select="$rowspacing"/><xsl:text>;</xsl:text>
                <xsl:text>margin-bottom:</xsl:text><xsl:value-of select="$rowspacing"/><xsl:text>;</xsl:text>
               </xsl:if>
               <xsl:if test="$columnspacing!=''">
                <xsl:text>margin-left:</xsl:text><xsl:value-of select="$columnspacing"/><xsl:text>;</xsl:text>
                <xsl:text>margin-right:</xsl:text><xsl:value-of select="$columnspacing"/><xsl:text>;</xsl:text>
               </xsl:if>
              </xsl:attribute>
              <xsl:apply-templates/>
             </xsl:element>
            </xsl:when>
            <xsl:otherwise>
             <xsl:apply-templates/>
            </xsl:otherwise>
           </xsl:choose>
          </xsl:element>
         </xsl:when>
         <xsl:otherwise>
          <xsl:apply-templates/>
         </xsl:otherwise>
        </xsl:choose>

       </td>
      </xsl:for-each>
     </tr>
    </xsl:for-each>
   </table>
  </xsl:element>
 </xsl:element>

 <xsl:variable name="parNode" select="following-sibling::dxl:par[1]"/>
 <xsl:variable name="attriDef">
  <xsl:choose>
   <xsl:when test="string-length($parNode/@def)=0">
    <xsl:call-template name="getDef">
     <xsl:with-param name="inputString">
      <xsl:call-template name="defsearch"/>
     </xsl:with-param>
    </xsl:call-template>
   </xsl:when>
   <xsl:otherwise><xsl:value-of select="$parNode/@def"/></xsl:otherwise>
  </xsl:choose>
 </xsl:variable>
 <xsl:variable name="hide">
  <xsl:if test="$attriDef!='0'">
   <xsl:value-of select="$parNode/preceding::dxl:pardef[@id=$attriDef]/@hide"/>
  </xsl:if>
 </xsl:variable>
 <xsl:if test="not(contains($hide, 'read') or contains($hide, 'notes'))">
  <xsl:element name="br"/>
 </xsl:if>

</xsl:template> 

<xsl:template match="dxl:code"> 
</xsl:template> 

<!--
**********************************************************************
罫線
********************************************************************** -->
<xsl:template match="dxl:horizrule">
 <span>
  <xsl:attribute name="style">
   <xsl:text>display:inline-block;</xsl:text>
   <xsl:choose>
    <xsl:when test="@gradientcolor!=''">
     <xsl:text>filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=</xsl:text>
     <xsl:call-template name="getColor">
      <xsl:with-param name="color" select="@color"/>
     </xsl:call-template>
     <xsl:text>,endColorStr=</xsl:text>
     <xsl:call-template name="getColor">
      <xsl:with-param name="color" select="@gradientcolor"/>
     </xsl:call-template>
     <xsl:text>);</xsl:text>
     <xsl:text>background-image:-webkit-linear-gradient(top,</xsl:text>
     <xsl:call-template name="getColor">
      <xsl:with-param name="color" select="@color"/>
     </xsl:call-template>
     <xsl:text>,</xsl:text>
     <xsl:call-template name="getColor">
      <xsl:with-param name="color" select="@gradientcolor"/>
     </xsl:call-template>
     <xsl:text>);</xsl:text>
    </xsl:when>
    <xsl:when test="@color!=''">
     <xsl:variable name="color">
      <xsl:call-template name="getColor">
       <xsl:with-param name="color" select="@color"/>
      </xsl:call-template>
     </xsl:variable>
     <xsl:text>background-color:</xsl:text><xsl:value-of select="$color"/><xsl:text>;</xsl:text>
     <xsl:text>border:solid 1px </xsl:text><xsl:value-of select="$color"/><xsl:text>;</xsl:text>
    </xsl:when>
   </xsl:choose>
   <xsl:if test="@width!=''">
    <xsl:variable name="str" select="@width"/>
    <xsl:variable name="len" select="string-length($str)"/>
    <xsl:variable name="wtype" select="substring($str,$len,1)"/>
    <xsl:if test="$wtype='n'">
        <xsl:variable name="width" select="substring($str,0,$len - 1)"/>
        <xsl:text>width:</xsl:text><xsl:value-of select="$width * 96"/><xsl:text>;</xsl:text>
    </xsl:if>
    <xsl:if test="$wtype='%'">
     <xsl:text>width:</xsl:text><xsl:value-of select="$str"/><xsl:text>;</xsl:text>
    </xsl:if>
   </xsl:if>

   <xsl:if test="@height!=''">
		<xsl:text>height:</xsl:text>
    <xsl:variable name="str" select="@height"/>
    <xsl:variable name="len" select="string-length($str)"/>
    <xsl:variable name="htype" select="substring($str,$len,1)"/>
    <xsl:if test="$htype='n'">
     <xsl:variable name="height" select="substring($str,0,$len - 1)"/>
     <xsl:value-of select="$height * 96"/>
    </xsl:if>
    <xsl:if test="$htype='%'">
     <xsl:value-of select="$str"/>
    </xsl:if>
    <xsl:text>;</xsl:text>
  </xsl:if>
  </xsl:attribute>
  <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#65279;')"/>
 </span>
</xsl:template>

<!--
**********************************************************************
getColor
********************************************************************** -->
<xsl:template name="getColor">
 <xsl:param name="color"/>
 <xsl:choose>
  <xsl:when test="$color='system'">
   <xsl:text>ButtonFace</xsl:text>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of select="$color"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
datetime
********************************************************************** -->
<xsl:template match="dxl:datetime">
<xsl:variable name="cDate"><xsl:value-of select="."/></xsl:variable>
<xsl:choose>
<xsl:when test="substring($cDate,1,1)='T'">
  <xsl:value-of select="concat(substring($cDate, 2, 2),':',substring($cDate, 4, 2),':',substring($cDate, 6, 2))"/>
</xsl:when>
<xsl:otherwise>
 <xsl:variable name="cYear"><xsl:value-of select="substring($cDate, 1,4 )"/></xsl:variable>
 <xsl:variable name="cMonth"><xsl:value-of select="substring($cDate, 5, 2)"/></xsl:variable>
 <xsl:variable name="cDay"><xsl:value-of select="substring($cDate, 7, 2)"/></xsl:variable>
 <xsl:variable name="cHour"><xsl:value-of select="substring($cDate, 10, 2)"/></xsl:variable>
 <xsl:variable name="cMin"><xsl:value-of select="substring($cDate, 12, 2)"/></xsl:variable>
 <xsl:variable name="cSec"><xsl:value-of select="substring($cDate, 14, 2)"/></xsl:variable>
 <xsl:if test="$cHour=''">
  <xsl:value-of select="concat($cYear,'/',$cMonth,'/',$cDay)"/>
 </xsl:if>
 <xsl:if test="$cHour!=''">
  <xsl:value-of select="concat($cYear,'/',$cMonth,'/',$cDay,$kara,$cHour,':',$cMin,':',$cSec)"/>
 </xsl:if>
</xsl:otherwise>
</xsl:choose>
</xsl:template>



<!--
**********************************************************************
日付リスト
********************************************************************** -->
<xsl:template match="dxl:datetimelist">
 <xsl:for-each select="dxl:datetime">
  <xsl:apply-templates select="."/><xsl:element name="br"/>
 </xsl:for-each>
 <xsl:for-each select="dxl:datetimepair">
  <xsl:for-each select="dxl:datetime">
   <xsl:if test="position()=1">
    <xsl:apply-templates select="."/><xsl:text> - </xsl:text>
   </xsl:if>
   <xsl:if test="position()=2">
    <xsl:apply-templates select="."/><xsl:text> </xsl:text><xsl:element name="br"/>
   </xsl:if>
  </xsl:for-each>
 </xsl:for-each>
</xsl:template>

<!--
**********************************************************************
break
********************************************************************** -->
<xsl:template match="dxl:break">
 <xsl:element name="br"/>
 <xsl:if test="count(parent::node()/following-sibling::node())=0 and count(following-sibling::node())=0">
  <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#65279;')"/>
 </xsl:if>
</xsl:template> 

<!--
**********************************************************************
text
********************************************************************** -->
<xsl:template match="dxl:text">
  <xsl:choose>
   <xsl:when test="string-length(.)=0">
    <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#65279;')"/>
   </xsl:when>
   <xsl:otherwise>
		<xsl:apply-templates />
   </xsl:otherwise>
  </xsl:choose>
</xsl:template> 

<!--
**********************************************************************
replace
********************************************************************** -->
<xsl:template name="SubstringReplace">
   <xsl:param name="text"/>
   <xsl:param name="replace" />
   <xsl:param name="by"  />
   <xsl:choose>
   <xsl:when test="contains($text, $replace)">
      <xsl:value-of select="substring-before($text, $replace)"/>
      <xsl:value-of select="$by" disable-output-escaping="yes"/>
      <xsl:call-template name="SubstringReplace">
         <xsl:with-param name="text" select="substring-after($text,$replace)"/>
         <xsl:with-param name="replace" select="$replace" />
         <xsl:with-param name="by" select="$by" />
      </xsl:call-template>
   </xsl:when>
   <xsl:otherwise>
      <xsl:value-of select="$text"/>
   </xsl:otherwise>
   </xsl:choose>
</xsl:template>	


<!--
**********************************************************************
popup
********************************************************************** -->
<xsl:template match="dxl:popup">
 <xsl:element name="span">
  <xsl:attribute name="style">
   <!-- Safari対応 ブロック要素として認識されるようにする -->
   <xsl:text>cursor:pointer;display:inline-block;</xsl:text>
   <xsl:choose>
    <xsl:when test="@hotspotstyle='highlight'">
     <xsl:text>background-color:khaki;</xsl:text>
    </xsl:when>
    <xsl:when test="@hotspotstyle='none'">
    </xsl:when>
    <xsl:otherwise>
     <xsl:text>display:inline-block;margin:1px 0px 2px;border:1px solid green;</xsl:text>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:attribute>
  <xsl:attribute name="title">
   <xsl:value-of select="dxl:popuptext"/>
  </xsl:attribute>
  <xsl:apply-templates />
 </xsl:element>
</xsl:template>


<!--
**********************************************************************
popuptext
********************************************************************** -->
<xsl:template match="dxl:popuptext">
</xsl:template>	


<!--
**********************************************************************
text()
********************************************************************** -->
<xsl:template match="text()">
 <xsl:variable name="partext" select="."/>
 <xsl:variable name="reptest"> 
  <xsl:choose>
   <xsl:when test="string-length(.)=0">
    <xsl:value-of disable-output-escaping="yes" select="concat($amp, '#160;')"/>
   </xsl:when>
   <xsl:otherwise>
    <!-- テキスト内のエスケープ対象文字を処理する -->
    <xsl:call-template name="EscapeAllText">
     <xsl:with-param name="text" select="."/>
    </xsl:call-template>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:variable>
 <xsl:choose>
  <xsl:when test="ancestor::dxl:run/@html='true'">
   <xsl:choose>
    <xsl:when test="contains($reptest,'richtext:')">
     <xsl:variable name="itemname"><xsl:text>dxl:item[@name='</xsl:text><xsl:value-of disable-output-escaping="yes" select="substring-after($reptest,'richtext:')"/><xsl:text>']</xsl:text></xsl:variable>
     <xsl:element name="xsl:if">
      <xsl:attribute name="test"><xsl:value-of disable-output-escaping="yes" select="$itemname"/><xsl:text>//text()!=''</xsl:text></xsl:attribute>
      <xsl:element name="div">
       <!-- table外のリッチテキストフィールドの場合のみ左マージンを調整 -->
       <xsl:if test="count(ancestor::dxl:tablecell)=0">
        <xsl:attribute name="style">margin-left:-1in</xsl:attribute>
       </xsl:if>
       <xsl:element name="xsl:apply-templates">
        <xsl:attribute name="select"><xsl:value-of disable-output-escaping="yes" select="$itemname"/></xsl:attribute>
       </xsl:element>
      </xsl:element>
     </xsl:element>
    </xsl:when>
    <xsl:otherwise>
     <xsl:variable name="itemname"><xsl:text>dxl:item[@name='</xsl:text><xsl:value-of disable-output-escaping="yes"  select="$reptest"/><xsl:text>']</xsl:text></xsl:variable>
     <xsl:element name="xsl:if">
      <xsl:attribute name="test"><xsl:value-of disable-output-escaping="yes" select="$itemname"/><xsl:text>//text()!=''</xsl:text></xsl:attribute>
      <xsl:element name="xsl:apply-templates">
       <xsl:attribute name="select"><xsl:value-of disable-output-escaping="yes" select="$itemname"/></xsl:attribute>
      </xsl:element>
     </xsl:element>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <xsl:otherwise>
   <xsl:choose>
    <xsl:when test="name(parent::*)='par'">
     <xsl:element name="font">
      <xsl:attribute name="face"><xsl:value-of select="$SansSerifFamily"/></xsl:attribute>
      <xsl:attribute name="style"><xsl:text>font-size:10pt;</xsl:text></xsl:attribute>
      <xsl:call-template name="outputText">
       <xsl:with-param name="source" select="$reptest"/>
      </xsl:call-template>
     </xsl:element>
    </xsl:when>
    <xsl:otherwise>
     <xsl:call-template name="outputText">
      <xsl:with-param name="source" select="$reptest"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
EscapeAllText
********************************************************************** -->
<xsl:template name="EscapeAllText">
 <xsl:param name="text"/>
 <xsl:variable name="maxLength" select="number(1000)"/>
 <xsl:choose>
  <!-- 文字数が長い場合、xalanでStackOverflowErrorが発生するため分割して処理する -->
  <xsl:when test="string-length($text)&gt;$maxLength">
   <xsl:call-template name="EscapeText">
    <xsl:with-param name="text" select="substring($text, 1, $maxLength)"/>
   </xsl:call-template>
   <xsl:call-template name="EscapeAllText">
    <xsl:with-param name="text" select="substring($text, $maxLength + 1)"/>
   </xsl:call-template>
  </xsl:when>
  <xsl:otherwise>
   <xsl:call-template name="EscapeText">
    <xsl:with-param name="text" select="$text"/>
   </xsl:call-template>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
EscapeText
********************************************************************** -->
<xsl:template name="EscapeText">
 <xsl:param name="text"/>
 <xsl:call-template name="SubstringReplace">
  <xsl:with-param name="text"><xsl:call-template name="SubstringReplace">
   <xsl:with-param name="text"><xsl:call-template name="SubstringReplace">
    <xsl:with-param name="text"><xsl:call-template name="SubstringReplace">
     <xsl:with-param name="text"><xsl:call-template name="SubstringReplace">
      <xsl:with-param name="text">
       <xsl:choose>
        <!-- item要素のnames属性がtrueの場合、省略形で出力する -->
        <xsl:when test="ancestor::dxl:item[@names='true']">
         <xsl:call-template name="formatName">
          <xsl:with-param name="text" select="$text"/>
         </xsl:call-template>
        </xsl:when>
        <xsl:otherwise>
         <xsl:value-of select="$text"/>
        </xsl:otherwise>
       </xsl:choose>
      </xsl:with-param>
      <xsl:with-param name="replace" select="$amp"/>
      <xsl:with-param name="by" select="concat($amp, 'amp;')"/></xsl:call-template>
     </xsl:with-param>
     <xsl:with-param name="replace" select="'　'"/>
     <xsl:with-param name="by" select="'  '"/>
    </xsl:call-template></xsl:with-param>
    <xsl:with-param name="replace" select="' '"/>
    <xsl:with-param name="by" select="concat($amp, '#160;')"/>
   </xsl:call-template></xsl:with-param>
   <xsl:with-param name="replace" select="'&lt;'"/>
   <xsl:with-param name="by" select="concat($amp, 'lt;')"/>
  </xsl:call-template></xsl:with-param>
  <xsl:with-param name="replace" select="'&gt;'"/>
  <xsl:with-param name="by" select="concat($amp, 'gt;')"/>
 </xsl:call-template>
</xsl:template>


<!--
**********************************************************************
outputText
********************************************************************** -->
<xsl:template name="outputText">
 <xsl:param name="source"/>

 <!-- http:// または https:// が文字列に含まれているか -->
 <xsl:variable name="httpText">
  <xsl:choose>
   <!-- URLホットスポットフラグが無効な場合、ホットスポットとしない -->
   <xsl:when test="$HotspotEnable != '1'">
   </xsl:when>
   <xsl:otherwise>
    <xsl:call-template name="getHttpText">
     <xsl:with-param name="source" select="$source"/>
    </xsl:call-template>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:variable>
 <xsl:choose>
  <!-- http:// または https:// が文字列に含まれている場合 -->
  <xsl:when test="$httpText!=''">
   <!-- http:// または https:// より前の文字列を取得 -->
   <xsl:variable name="beforeText">
    <xsl:value-of select="substring-before($source, $httpText)"/>
   </xsl:variable>
   <xsl:choose>
    <!-- http:// または https:// より前の文字列が存在する場合 -->
    <xsl:when test="$beforeText!=''">
     <xsl:choose>
      <!-- 前の文字が半角スペースの場合 -->
      <xsl:when test="concat($amp, '#160;') = substring($beforeText, string-length($beforeText) - 5, 6)">
       <xsl:call-template name="createHotspotLink">
        <xsl:with-param name="source" select="$source"/>
        <xsl:with-param name="httpText" select="$httpText"/>
       </xsl:call-template>
      </xsl:when>
      <!-- 前の文字が小なり記号の場合 -->
      <xsl:when test="concat($amp, 'lt;') = substring($beforeText, string-length($beforeText) - 3, 4)">
       <xsl:call-template name="createHotspotLink">
        <xsl:with-param name="source" select="$source"/>
        <xsl:with-param name="httpText" select="$httpText"/>
       </xsl:call-template>
      </xsl:when>
      <!-- 前の文字が大なり記号の場合 -->
      <xsl:when test="concat($amp, 'gt;') = substring($beforeText, string-length($beforeText) - 3, 4)">
       <xsl:call-template name="createHotspotLink">
        <xsl:with-param name="source" select="$source"/>
        <xsl:with-param name="httpText" select="$httpText"/>
       </xsl:call-template>
      </xsl:when>
      <!-- 前の文字が特定の文字の場合 -->
      <xsl:when test="contains('(:&quot;,;[]{}', substring($beforeText, string-length($beforeText), 1))">
       <xsl:call-template name="createHotspotLink">
        <xsl:with-param name="source" select="$source"/>
        <xsl:with-param name="httpText" select="$httpText"/>
       </xsl:call-template>
      </xsl:when>
      <!-- 前の文字が上記以外の文字の場合 -->
      <xsl:otherwise>
       <xsl:value-of disable-output-escaping="yes" select="$source"/>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:when>
    <!-- http:// または https:// より前の文字列が存在しない場合 -->
    <xsl:otherwise>
     <xsl:call-template name="createHotspotLink">
      <xsl:with-param name="source" select="$source"/>
      <xsl:with-param name="httpText" select="$httpText"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <!-- http:// または https:// が含まれていない場合 -->
  <xsl:otherwise>
   <xsl:value-of disable-output-escaping="yes" select="$source"/>
  </xsl:otherwise>
 </xsl:choose>

</xsl:template>

<!--
**********************************************************************
getHttpText
********************************************************************** -->
<xsl:template name="getHttpText">
 <xsl:param name="source"/>

 <xsl:if test="contains($source, '://')">
  <xsl:variable name="beforeText" select="substring-before($source, '://')"/>
  <xsl:variable name="httpText" select="substring($beforeText, string-length($beforeText) - 3, 4)"/>
  <xsl:variable name="httpsText" select="substring($beforeText, string-length($beforeText) - 4, 5)"/>
  <xsl:choose>
   <xsl:when test="translate($httpText, 'HTP', 'htp')='http'">
    <xsl:value-of select="$httpText"/><xsl:text>://</xsl:text>
   </xsl:when>
   <xsl:when test="translate($httpsText, 'HTPS', 'htps')='https'">
    <xsl:value-of select="$httpsText"/><xsl:text>://</xsl:text>
   </xsl:when>
   <xsl:otherwise>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:if>
</xsl:template>

<!--
**********************************************************************
getHotspotText
※本テンプレート変更時には「getAfterText」についても考慮すること
********************************************************************** -->
<xsl:template name="getHotspotText">
 <xsl:param name="source"/>
 <xsl:param name="index"/>

 <xsl:choose>
  <xsl:when test="string-length($source) &gt;= number($index)">
   <xsl:choose>
    <!-- 後の文字が半角スペースの場合 -->
    <xsl:when test="concat($amp, '#160;') = substring($source, $index, 6)">
     <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
    </xsl:when>
    <!-- 後の文字が小なり記号の場合 -->
    <xsl:when test="concat($amp, 'lt;') = substring($source, $index, 4)">
     <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
    </xsl:when>
    <!-- 後の文字が大なり記号の場合 -->
    <xsl:when test="concat($amp, 'gt;') = substring($source, $index, 4)">
     <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
    </xsl:when>
    <!-- 後の文字がアンパサンドの場合 -->
    <xsl:when test="concat($amp, 'amp;') = substring($source, $index, 5)">
     <xsl:call-template name="getHotspotText">
      <xsl:with-param name="source" select="$source"/>
      <xsl:with-param name="index" select="$index + 5"/>
     </xsl:call-template>
    </xsl:when>
    <!-- 後の文字が右丸カッコの場合 -->
    <xsl:when test="')' = substring($source, $index, 1)">
     <xsl:choose>
      <!-- 現在の右丸カッコより前に左丸カッコが存在する場合 -->
      <xsl:when test="contains(substring($source, 1, $index - 1), '(')">
       <xsl:choose>
        <!-- 現在の右丸カッコより前に右丸カッコが存在する（括弧が複数存在する）場合 -->
        <xsl:when test="contains(substring($source, 1, $index - 1), ')')">
         <!-- 最後の右丸カッコの位置を取得 -->
         <xsl:variable name="lastIndex">
          <xsl:call-template name="lastIndexOf">
           <xsl:with-param name="source" select="substring($source, 1, $index - 1)"/>
           <xsl:with-param name="target" select="')'"/>
           <xsl:with-param name="index" select="1"/>
          </xsl:call-template>
         </xsl:variable>
         <xsl:choose>
          <!-- 最後の右丸カッコより後に左丸カッコが存在する場合 -->
          <xsl:when test="contains(substring($source, $lastIndex + 1, $index - 1), '(')">
           <xsl:call-template name="getHotspotText">
            <xsl:with-param name="source" select="$source"/>
            <xsl:with-param name="index" select="$index + 1"/>
           </xsl:call-template>
          </xsl:when>
          <xsl:otherwise>
           <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
          </xsl:otherwise>
         </xsl:choose>
        </xsl:when>
        <!-- 初めて出現する右丸カッコの場合 -->
        <xsl:otherwise>
         <xsl:call-template name="getHotspotText">
          <xsl:with-param name="source" select="$source"/>
          <xsl:with-param name="index" select="$index + 1"/>
         </xsl:call-template>
        </xsl:otherwise>
       </xsl:choose>
      </xsl:when>
      <!-- 対応する左丸カッコが存在しない場合 -->
      <xsl:otherwise>
       <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:when>
    <!-- 後の文字がシングルクォーテーションの場合 -->
    <xsl:when test="$apos = substring($source, $index, 1)">
     <xsl:call-template name="getHotspotText">
      <xsl:with-param name="source" select="$source"/>
      <xsl:with-param name="index" select="$index + 1"/>
     </xsl:call-template>
    </xsl:when>
    <!-- 後の文字がカンマ、ピリオド、セミコロンの場合 -->
    <xsl:when test="contains(',.;', substring($source, $index, 1))">
     <!-- カンマ、ピリオド、セミコロンの連続数を取得 -->
     <xsl:variable name="repeatedCount">
      <xsl:call-template name="getRepeatedCount">
       <xsl:with-param name="source" select="substring($source, $index + 1)"/>
       <xsl:with-param name="repeatedChars" select="',.;'"/>
       <xsl:with-param name="repeatedCount" select="1"/>
      </xsl:call-template>
     </xsl:variable>
     <!-- カンマ、ピリオド、セミコロンの直後に続く文字がURL内かどうかを確認 -->
     <xsl:variable name="afterText">
      <xsl:call-template name="getAfterText">
       <xsl:with-param name="source" select="$source"/>
       <xsl:with-param name="index" select="number($index) + number($repeatedCount)"/>
      </xsl:call-template>
     </xsl:variable>
     <xsl:choose>
      <xsl:when test="string-length($afterText)=0">
       <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
      </xsl:when>
      <xsl:otherwise>
       <xsl:call-template name="getHotspotText">
        <xsl:with-param name="source" select="$source"/>
        <xsl:with-param name="index" select="number($index) + number($repeatedCount) + string-length($afterText)"/>
       </xsl:call-template>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:when>
    <!-- 後の文字が特定の文字列の場合 -->
    <xsl:when test="contains('&quot;[]{}', substring($source, $index, 1))">
     <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
    </xsl:when>
    <!-- 後の文字が特定の文字列以外の場合 -->
    <xsl:when test="not(contains('0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%#$-_.+!*(),;/:@=~\|?', substring($source, $index, 1)))">
     <xsl:value-of disable-output-escaping="yes" select="substring($source, 1, $index - 1)"/>
    </xsl:when>
    <!-- 後の文字が上記以外の文字列の場合 -->
    <xsl:otherwise>
     <xsl:call-template name="getHotspotText">
      <xsl:with-param name="source" select="$source"/>
      <xsl:with-param name="index" select="$index + 1"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of disable-output-escaping="yes" select="$source"/>
  </xsl:otherwise>
 </xsl:choose>

</xsl:template>

<!--
**********************************************************************
getAfterText
※カンマ、ピリオド、セミコロンの直後に続く文字がURL内の場合は文字を返す
※本テンプレート変更時には「getHotspotText」についても考慮すること
********************************************************************** -->
<xsl:template name="getAfterText">
 <xsl:param name="source"/>
 <xsl:param name="index"/>

 <xsl:if test="string-length($source) &gt;= number($index)">
  <xsl:choose>
   <!-- 後の文字が半角スペースの場合 -->
   <xsl:when test="concat($amp, '#160;') = substring($source, $index, 6)">
   </xsl:when>
   <!-- 後の文字が小なり記号の場合 -->
   <xsl:when test="concat($amp, 'lt;') = substring($source, $index, 4)">
   </xsl:when>
   <!-- 後の文字が大なり記号の場合 -->
   <xsl:when test="concat($amp, 'gt;') = substring($source, $index, 4)">
   </xsl:when>
   <!-- 後の文字がアンパサンドの場合 -->
   <xsl:when test="concat($amp, 'amp;') = substring($source, $index, 5)">
    <xsl:value-of disable-output-escaping="yes" select="substring($source, $index, 5)"/>
   </xsl:when>
   <!-- 後の文字が右丸カッコの場合 -->
   <xsl:when test="')' = substring($source, $index, 1)">
    <xsl:choose>
     <!-- 現在の右丸カッコより前に左丸カッコが存在する場合 -->
     <xsl:when test="contains(substring($source, 1, $index - 1), '(')">
      <xsl:choose>
       <!-- 現在の右丸カッコより前に右丸カッコが存在する（括弧が複数存在する）場合 -->
       <xsl:when test="contains(substring($source, 1, $index - 1), ')')">
        <!-- 最後の右丸カッコの位置を取得 -->
        <xsl:variable name="lastIndex">
         <xsl:call-template name="lastIndexOf">
          <xsl:with-param name="source" select="substring($source, 1, $index - 1)"/>
          <xsl:with-param name="target" select="')'"/>
          <xsl:with-param name="index" select="1"/>
         </xsl:call-template>
        </xsl:variable>
        <xsl:choose>
         <!-- 最後の右丸カッコより後に左丸カッコが存在する場合 -->
         <xsl:when test="contains(substring($source, $lastIndex + 1, $index - 1), '(')">
          <xsl:value-of disable-output-escaping="yes" select="substring($source, $index, 1)"/>
         </xsl:when>
         <xsl:otherwise>
         </xsl:otherwise>
        </xsl:choose>
       </xsl:when>
       <!-- 初めて出現する右丸カッコの場合 -->
       <xsl:otherwise>
        <xsl:value-of disable-output-escaping="yes" select="substring($source, $index, 1)"/>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:when>
     <!-- 対応する左丸カッコが存在しない場合 -->
     <xsl:otherwise>
     </xsl:otherwise>
    </xsl:choose>
   </xsl:when>
   <!-- 後の文字がシングルクォーテーションの場合 -->
   <xsl:when test="$apos = substring($source, $index, 1)">
    <xsl:value-of disable-output-escaping="yes" select="substring($source, $index, 1)"/>
   </xsl:when>
   <!-- 後の文字が特定の文字列の場合 -->
   <xsl:when test="contains('&quot;[]{}', substring($source, $index, 1))">
   </xsl:when>
   <!-- 後の文字が特定の文字列以外の場合 -->
   <xsl:when test="not(contains('0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%#$-_.+!*(),;/:@=~\|?', substring($source, $index, 1)))">
   </xsl:when>
   <!-- 後の文字が上記以外の文字列の場合 -->
   <xsl:otherwise>
    <xsl:value-of disable-output-escaping="yes" select="substring($source, $index, 1)"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:if>

</xsl:template>

<!--
**********************************************************************
getRepeatedCount
********************************************************************** -->
<xsl:template name="getRepeatedCount">
 <xsl:param name="source"/>
 <xsl:param name="repeatedChars"/>
 <xsl:param name="repeatedCount"/>

 <xsl:choose>
  <xsl:when test="contains($repeatedChars, substring($source, 1, 1))">
   <xsl:choose>
    <xsl:when test="string-length($source)&gt;1">
     <xsl:call-template name="getRepeatedCount">
      <xsl:with-param name="source" select="substring($source, 2)"/>
      <xsl:with-param name="repeatedChars" select="$repeatedChars"/>
      <xsl:with-param name="repeatedCount" select="number($repeatedCount) + 1"/>
     </xsl:call-template>
    </xsl:when>
    <xsl:otherwise>
     <xsl:value-of select="$repeatedCount"/>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of select="$repeatedCount"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
createHotspotLink
********************************************************************** -->
<xsl:template name="createHotspotLink">
 <xsl:param name="source"/>
 <xsl:param name="httpText"/>

 <!-- ホットスポット対象文字列を取得 -->
 <xsl:variable name="hotspotText">
  <xsl:call-template name="getHotspotText">
   <xsl:with-param name="source" select="substring-after($source, $httpText)"/>
   <xsl:with-param name="index" select="1"/>
  </xsl:call-template>
 </xsl:variable>
 <xsl:choose>
  <!-- ホットスポット対象文字列が存在する場合 -->
  <xsl:when test="$hotspotText!=''">
   <xsl:value-of disable-output-escaping="yes" select="substring-before($source, $httpText)"/>
   <xsl:text disable-output-escaping="yes">&lt;a href="</xsl:text>
   <xsl:value-of disable-output-escaping="yes" select="concat($httpText, $hotspotText)"/>
   <xsl:text disable-output-escaping="yes">"></xsl:text>
   <xsl:value-of disable-output-escaping="yes" select="concat($httpText, $hotspotText)"/>
   <xsl:text disable-output-escaping="yes">&lt;/a></xsl:text>
   <xsl:variable name="afterText">
    <xsl:value-of disable-output-escaping="yes" select="substring-after($source, $hotspotText)"/>
   </xsl:variable>
   <xsl:choose>
    <xsl:when test="contains($afterText, '://')">
     <xsl:call-template name="outputText">
      <xsl:with-param name="source" select="$afterText"/>
     </xsl:call-template>
    </xsl:when>
    <xsl:otherwise>
     <xsl:value-of disable-output-escaping="yes" select="$afterText"/>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <!-- ホットスポット対象文字列が存在しない場合 -->
  <xsl:otherwise>
   <xsl:value-of disable-output-escaping="yes" select="$source"/>
  </xsl:otherwise>
 </xsl:choose>

</xsl:template>


<!--
**********************************************************************
string-byte
********************************************************************** -->
<xsl:template name="string-byte">
 <xsl:param name="string"/>
 <xsl:param name="allByte"/>

 <xsl:choose>
  <xsl:when test="string-length($string)=0">
   <xsl:value-of select="allByte"/>
  </xsl:when>
  <xsl:otherwise>
   <xsl:variable name="byte">
    <xsl:choose>
     <!-- 半角文字の場合 -->
     <xsl:when test="contains($OneByteChars, substring($string, 1, 1))">
      <xsl:text>1</xsl:text>
     </xsl:when>
     <!-- 全角文字の場合 -->
     <xsl:otherwise>
      <xsl:text>2</xsl:text>
     </xsl:otherwise>
    </xsl:choose>
   </xsl:variable>
   <xsl:choose>
    <xsl:when test="string-length($string)=1">
     <xsl:value-of select="$allByte"/>
    </xsl:when>
    <xsl:otherwise>
     <xsl:call-template name="string-byte">
      <xsl:with-param name="string" select="substring($string, 2)"/>
      <xsl:with-param name="allByte" select="number($allByte) + number($byte)"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>


<!--
**********************************************************************
embeddedcontrol
********************************************************************** -->
<xsl:template match="dxl:embeddedcontrol">
 <xsl:call-template name="runelement"/>
</xsl:template>


<!--
**********************************************************************
embeddedkeywords
********************************************************************** -->
<xsl:template match="dxl:embeddedkeywords">
 <xsl:variable name="embno">
  <xsl:text>emb</xsl:text><xsl:number level="any" count="dxl:embeddedcontrol"/>
 </xsl:variable>
 <xsl:variable name="type">
  <xsl:value-of select="../@type" />
 </xsl:variable>

 <xsl:choose>
  <!-- ラジオボタン、チェックボックスの場合 -->
  <xsl:when test="$type='radiobutton' or $type='checkbox'">
   <xsl:for-each select="dxl:keyword">
    <!-- 裏値を考慮し表示値を取得 -->
    <xsl:variable name="keystr" select="./text()"/>
    <xsl:variable name="value">
     <xsl:choose>
      <xsl:when test="contains($keystr,'|')">
       <xsl:value-of select="substring-before($keystr,'|')"/>
      </xsl:when>
      <xsl:otherwise>
       <xsl:value-of select="$keystr"/>
      </xsl:otherwise>
     </xsl:choose>
    </xsl:variable>
    <!-- 各表示値を出力 -->
    <xsl:element name="input">
     <xsl:choose>
      <xsl:when test="$type='radiobutton'">
       <xsl:attribute name="type"><xsl:text>radio</xsl:text></xsl:attribute>
      </xsl:when>
      <xsl:otherwise>
       <xsl:attribute name="type"><xsl:value-of select="$type"/></xsl:attribute>
      </xsl:otherwise>
     </xsl:choose>
     <xsl:attribute name="name"><xsl:value-of select="$embno"/></xsl:attribute>
     <xsl:attribute name="value"><xsl:value-of select="$value"/></xsl:attribute>
     <xsl:if test="@on='true'">
      <xsl:attribute name="checked"><xsl:text>checked</xsl:text></xsl:attribute>
     </xsl:if>
    </xsl:element>
    <xsl:value-of select="$value"/>
   </xsl:for-each>
  </xsl:when>
  <!-- コンボボックス、リストボックスの場合 -->
  <xsl:when test="$type='combobox' or $type='listbox'">
   <xsl:element name="select">
    <xsl:attribute name="name"><xsl:value-of select="$embno"/></xsl:attribute>
    <xsl:attribute name="style">
     <xsl:text>width:</xsl:text><xsl:value-of select="../@width"/><xsl:text>;</xsl:text>
     <xsl:text>height:</xsl:text><xsl:value-of select="../@height"/><xsl:text>;</xsl:text>
    </xsl:attribute>
    <xsl:choose>
     <xsl:when test="$type='combobox'">
      <xsl:attribute name="size"><xsl:text>1</xsl:text></xsl:attribute>
     </xsl:when>
     <xsl:otherwise>
      <xsl:attribute name="size"><xsl:value-of select="../@columns"/></xsl:attribute>
      <xsl:if test="../@allowmultilines='true'">
       <xsl:attribute name="multiple"/>
      </xsl:if>
     </xsl:otherwise>
    </xsl:choose>

    <xsl:for-each select="dxl:keyword">
     <!-- 裏値を考慮し表示値を取得 -->
     <xsl:variable name="keystr" select="./text()"/>
     <xsl:variable name="value">
      <xsl:choose>
       <xsl:when test="contains($keystr,'|')">
        <xsl:value-of select="substring-before($keystr,'|')"/>
       </xsl:when>
       <xsl:otherwise>
        <xsl:value-of select="$keystr"/>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:variable>
     <!-- 各表示値を出力 -->
     <xsl:element name="option">
      <xsl:attribute name="value"><xsl:value-of select="$value"/></xsl:attribute>
      <xsl:if test="@on='true'">
       <xsl:attribute name="selected"><xsl:text>selected</xsl:text></xsl:attribute>
      </xsl:if>
      <xsl:value-of select="$value"/>
     </xsl:element>
    </xsl:for-each>
   </xsl:element>
  </xsl:when>
  <xsl:otherwise></xsl:otherwise>
 </xsl:choose>
</xsl:template>

<!--
**********************************************************************
createDoclinkForREF
※パラメータとして受け取った$REFの文書リンクを生成
********************************************************************** -->
<xsl:template name="createDoclinkForREF">
 <xsl:if test="$REF!=''">
  <xsl:element name="a">
   <xsl:attribute name="href">
    <xsl:text>./</xsl:text><xsl:value-of select="$REF"/><xsl:text>.html</xsl:text>
   </xsl:attribute>
   <xsl:element name="img">
    <xsl:attribute name="src"><xsl:text>../../domino/doclink.gif</xsl:text></xsl:attribute>
    <xsl:attribute name="style"><xsl:text>border-width:0px;</xsl:text></xsl:attribute>
   </xsl:element>
  </xsl:element>
 </xsl:if>
</xsl:template>

<!--
**********************************************************************
lastIndexOf
********************************************************************** -->
<xsl:template name="lastIndexOf">
 <xsl:param name="source"/>
 <xsl:param name="target"/>
 <xsl:param name="index"/>

 <xsl:variable name="sourceLength" select="string-length($source)"/>
 <xsl:variable name="targetLength" select="string-length($target)"/>

 <xsl:choose>
  <xsl:when test="$sourceLength &gt;= $index + $targetLength - 1">
   <xsl:choose>
    <xsl:when test="substring($source, $sourceLength - ($index - 1) - $targetLength + 1, $targetLength) = $target">
     <xsl:value-of select="$sourceLength - ($index - 1) - $targetLength + 1"/>
    </xsl:when>
    <xsl:otherwise>
     <xsl:call-template name="lastIndexOf">
      <xsl:with-param name="source" select="$source"/>
      <xsl:with-param name="target" select="$target"/>
      <xsl:with-param name="index" select="$index + $targetLength"/>
     </xsl:call-template>
    </xsl:otherwise>
   </xsl:choose>
  </xsl:when>
  <xsl:otherwise>
   <xsl:value-of select="number(-1)"/>
  </xsl:otherwise>
 </xsl:choose>
</xsl:template>
<!--フォーム変換処理-->
<xsl:template match="/">
        <!--フォームレイアウトのCSS定義部-->
        <xsl:for-each select="//dxl:pardef">
         <xsl:call-template name="pardef"/>
        </xsl:for-each>
        <!-- par要素のdef属性が取得できなかった場合の標準スタイル -->
        <xsl:text disable-output-escaping="yes">
<![CDATA[
		.defaultclass0{
				padding-left:1in;
				line-height:normal;
				text-align:left;
			}
]]> </xsl:text>
       <!--セクション動作のJavaScript関数部-->
       <xsl:call-template name="css-block"/>
</xsl:template>
</xsl:stylesheet>