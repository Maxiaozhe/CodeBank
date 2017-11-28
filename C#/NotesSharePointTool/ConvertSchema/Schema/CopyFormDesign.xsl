<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dxl="http://www.lotus.com/dxl" version="1.0">
 <xsl:output method="xml" encoding="UTF-8"/>

 <!--
 **********************************************************************
 グローバル変数
 ********************************************************************** -->
 <!-- 縦棒 -->
 <xsl:variable name="v_var">|</xsl:variable>

 <!-- section要素直下の最後のpar要素のdef属性値リスト -->
 <xsl:variable name="lastPardefInSection">
  <xsl:for-each select="//dxl:section">
   <xsl:for-each select="dxl:par">
    <xsl:if test="not(following-sibling::dxl:par)">
     <xsl:value-of select="$v_var"/>
     <xsl:value-of select="@def"/>
     <xsl:value-of select="$v_var"/>
    </xsl:if>
   </xsl:for-each>
  </xsl:for-each>
 </xsl:variable>

 <!--
 **********************************************************************
 root要素
 ********************************************************************** -->
 <xsl:template match="/">
  <xsl:apply-templates select="//dxl:body/dxl:richtext"/>
 </xsl:template>

 <!--
 **********************************************************************
 richtext要素
 ********************************************************************** -->
 <xsl:template match="dxl:richtext">
  <!--
   フォームの先頭段落が「IBM Notes R4.6」により非表示の場合、読み込み時に「フィールドを配置できません」エラーが発生し、
   リッチテキストフィールドの『が表示されなくなってしまうため、空の段落を強制的に挿入。
   また、フォーム設計読み込みの結果、フォームの最終段落が「IBM Notes R4.6」により非表示となる場合、
   リッチテキストフィールドの』が表示されなくなってしまうため、空の段落を強制的に挿入。
   （最終段落の場合は空の段落を1つ挿入しただけでは』が表示されないままの場合があるため、2つ挿入）
  -->
  <xsl:element name="pardef"><xsl:attribute name="id">0</xsl:attribute></xsl:element>
  <xsl:element name="par"><xsl:attribute name="def">0</xsl:attribute></xsl:element>
  <xsl:apply-templates/>
  <xsl:element name="par"><xsl:attribute name="def">0</xsl:attribute></xsl:element>
  <xsl:element name="par"><xsl:attribute name="def">0</xsl:attribute></xsl:element>
 </xsl:template>

 <!--
 **********************************************************************
 全要素
 ********************************************************************** -->
 <xsl:template match="*">
  <xsl:call-template name="copyNode"/>
 </xsl:template>

 <!--
 **********************************************************************
 pardef要素
 ********************************************************************** -->
 <xsl:template match="dxl:pardef">
  <xsl:variable name="id" select="@id"/>
  <xsl:choose>
   <!-- 対応するpar要素が存在しない場合は出力しない -->
   <xsl:when test="not(following::dxl:par[@def=$id])">
   </xsl:when>
   <!-- 
    読み込みモードで非表示の場合は出力しない
    ただし、section要素の最後のpar要素の場合は除外（DXLの構造としておかしくなるため）
   -->
   <xsl:when test="contains(@hide, 'read') and not(contains($lastPardefInSection, concat(concat($v_var, $id), $v_var)))">
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="{local-name()}">
     <xsl:for-each select="@*">
      <xsl:choose>
       <!-- hide属性の場合 -->
       <xsl:when test="local-name()='hide'">
        <!-- 編集モードでも非表示とならないようにする -->
        <xsl:variable name="hideTokens"><xsl:value-of select="."/></xsl:variable>
        <xsl:choose>
         <xsl:when test="contains($hideTokens, 'edit')">
          <xsl:variable name="newHideTokens">
           <xsl:call-template name="SubstringReplace">
            <xsl:with-param name="text">
             <xsl:call-template name="SubstringReplace">
              <xsl:with-param name="text">
               <xsl:call-template name="SubstringReplace">
                <xsl:with-param name="text">
                 <xsl:call-template name="SubstringReplace">
                  <xsl:with-param name="text" select="$hideTokens"/>
                  <xsl:with-param name="replace" select="'previewedit'"/>
                  <xsl:with-param name="by" select="'*'"/>
                 </xsl:call-template>
                </xsl:with-param>
                <xsl:with-param name="replace" select="'edit'"/>
                <xsl:with-param name="by" select="''"/>
               </xsl:call-template>
              </xsl:with-param>
              <xsl:with-param name="replace" select="'*'"/>
              <xsl:with-param name="by" select="'previewedit'"/>
             </xsl:call-template>
            </xsl:with-param>
            <xsl:with-param name="replace" select="'  '"/>
            <xsl:with-param name="by" select="' '"/>
           </xsl:call-template>
          </xsl:variable>
          <xsl:if test="$newHideTokens!=''">
           <xsl:attribute name="hide">
            <xsl:choose>
             <xsl:when test="substring($newHideTokens, 1, 1)=' '">
              <xsl:value-of select="substring($newHideTokens, 2)"/>
             </xsl:when>
             <xsl:when test="substring($newHideTokens, string-length($newHideTokens) - 1, 1)=' '">
              <xsl:value-of select="substring($newHideTokens, 1, string-length($newHideTokens) - 1)"/>
             </xsl:when>
             <xsl:otherwise>
              <xsl:value-of select="substring($newHideTokens, 1)"/>
             </xsl:otherwise>
            </xsl:choose>
           </xsl:attribute>
          </xsl:if>
         </xsl:when>
         <xsl:otherwise>
          <xsl:copy-of select="."/>
         </xsl:otherwise>
        </xsl:choose>
       </xsl:when>
       <xsl:otherwise>
        <xsl:copy-of select="."/>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:for-each>
     <xsl:apply-templates/>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 par要素
 ********************************************************************** -->
 <xsl:template match="dxl:par">
  <xsl:variable name="def" select="@def"/>
  <xsl:variable name="pardefNode" select="preceding::dxl:pardef[@id=$def]"/>
  <xsl:choose>
   <!-- 読み込みモードで非表示の場合は出力しない
    ただし、section要素の最後のpar要素の場合は除外（DXLの構造としておかしくなるため）
   -->
   <xsl:when test="contains($pardefNode/@hide, 'read') and not(contains($lastPardefInSection, concat(concat($v_var, $def), $v_var)) and not(following-sibling::dxl:par))">
   </xsl:when>
   <xsl:otherwise>
    <xsl:call-template name="copyNode"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 section要素
 ********************************************************************** -->
 <xsl:template match="dxl:section">
  <xsl:variable name="pardef" select="dxl:sectiontitle/@pardef"/>
  <xsl:variable name="pardefNode" select="preceding::dxl:pardef[@id=$pardef]"/>
  <xsl:choose>
   <!-- 読み込みモードで非表示の場合は出力しない -->
   <xsl:when test="contains($pardefNode/@hide, 'read')">
   </xsl:when>
   <xsl:otherwise>
    <xsl:element name="{local-name()}">
     <xsl:for-each select="@*">
      <!-- 制限付きセクションは設計要素のみでしか使用できないため、関連する属性以外をコピー -->
      <xsl:if test="local-name()!='accessfieldkind' and local-name()!='accessfieldname'">
       <xsl:copy-of select="."/>
      </xsl:if>
     </xsl:for-each>
     <xsl:apply-templates/>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 run要素
 ********************************************************************** -->
 <xsl:template match="dxl:run">
  <xsl:choose>
   <!-- field要素、またはsharedfieldref要素を含む場合 -->
   <xsl:when test="count(dxl:field)!=0 or count(dxl:sharedfieldref)!=0">
    <xsl:choose>
     <!-- 表示用の計算結果の場合 -->
     <xsl:when test="dxl:field/@kind='computedfordisplay'">
      <xsl:variable name="fixedText">
       <xsl:call-template name="getFixedText">
        <xsl:with-param name="formula" select="dxl:field/dxl:code/dxl:formula/text()"/>
       </xsl:call-template>
      </xsl:variable>
      <xsl:choose>
       <!-- 固定値の場合はパススルーHTMLにしない -->
       <xsl:when test="$fixedText!=''">
        <xsl:call-template name="copyNode"/>
       </xsl:when>
       <!-- 固定値以外の場合はパススルーHTMLにする -->
       <xsl:otherwise>
        <xsl:element name="{local-name()}">
         <xsl:copy-of select="@*"/>
         <xsl:attribute name="html"><xsl:text>true</xsl:text></xsl:attribute>
         <xsl:apply-templates/>
        </xsl:element>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:when>
     <!-- 表示用の計算結果以外の場合 -->
     <xsl:otherwise>
      <!-- パススルーHTMLにする -->
      <xsl:element name="{local-name()}">
       <xsl:copy-of select="@*"/>
       <xsl:attribute name="html"><xsl:text>true</xsl:text></xsl:attribute>
       <xsl:apply-templates/>
      </xsl:element>
     </xsl:otherwise>
    </xsl:choose>
   </xsl:when>
   <xsl:otherwise>
    <xsl:call-template name="copyNode"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 field要素
 ********************************************************************** -->
 <xsl:template match="dxl:field">
  <xsl:choose>
   <!-- 表示用の計算結果の場合 -->
   <xsl:when test="@kind='computedfordisplay'">
    <xsl:variable name="fixedText">
     <xsl:call-template name="getFixedText">
      <xsl:with-param name="formula" select="dxl:code/dxl:formula/text()"/>
     </xsl:call-template>
    </xsl:variable>
    <xsl:choose>
     <!-- 固定値の場合は囲み文字(")を除いて出力 -->
     <xsl:when test="$fixedText!=''">
      <xsl:value-of select="$fixedText"/>
     </xsl:when>
     <!-- 固定値以外の場合、フィールド名を出力 -->
     <xsl:otherwise>
      <xsl:call-template name="convertField">
       <xsl:with-param name="value" select="@name"/>
      </xsl:call-template>
     </xsl:otherwise>
    </xsl:choose>
   </xsl:when>
   <!-- 表示用の計算結果以外の場合 -->
   <xsl:otherwise>
    <!-- フィールド名を出力 -->
    <xsl:call-template name="convertField">
     <xsl:with-param name="value" select="@name"/>
    </xsl:call-template>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 sharedfieldref要素
 ********************************************************************** -->
 <xsl:template match="dxl:sharedfieldref">
  <xsl:choose>
   <!-- 親要素がrun要素である場合 -->
   <xsl:when test="parent::dxl:run">
    <!-- field名をテキストとして出力 -->
    <xsl:value-of select="@name"/>
   </xsl:when>
   <!-- 親要素がrun要素でない場合 -->
   <xsl:otherwise>
    <!-- パススルーHTMLにするためにrun要素で囲む -->
    <xsl:element name="run">
     <xsl:attribute name="html"><xsl:text>true</xsl:text></xsl:attribute>
     <xsl:value-of select="@name"/>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 actionhotspot要素
 ********************************************************************** -->
 <xsl:template match="dxl:actionhotspot">
  <xsl:apply-templates/>
 </xsl:template>

 <!--
 **********************************************************************
 computedtext要素
 ********************************************************************** -->
 <xsl:template match="dxl:computedtext">
  <xsl:variable name="fixedText">
   <xsl:call-template name="getFixedText">
    <xsl:with-param name="formula" select="dxl:code/dxl:formula/text()"/>
   </xsl:call-template>
  </xsl:variable>
  <!-- 固定値の場合は囲み文字(")を除いて出力 -->
  <xsl:if test="$fixedText!=''">
   <xsl:value-of select="$fixedText"/>
  </xsl:if>
 </xsl:template>

 <!--
 **********************************************************************
 code要素
  dxl:pardef/dxl:code : 非表示式
  dxl:section/dxl:code : アクセス式
  dxl:field/dxl:code : デフォルト値など
  dxl:button/dxl:code : 実行ロジック
 ********************************************************************** -->
 <xsl:template match="dxl:code">
  <!--
   sectiontitle要素はtext要素かcode要素を子要素として必要とするため、
   sectiontitle要素の子要素の場合は空のtext要素を出力する
  -->
  <xsl:if test="parent::dxl:sectiontitle">
   <xsl:element name="text"/>
  </xsl:if>
 </xsl:template>

 <!--
 **********************************************************************
 formregionbegin要素
 ********************************************************************** -->
 <xsl:template match="dxl:formregionbegin">
 </xsl:template>

 <!--
 **********************************************************************
 formregionend要素
 ********************************************************************** -->
 <xsl:template match="dxl:formregionend">
 </xsl:template>

 <!--
 **********************************************************************
 compositedata要素
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
 <!-- ファイルアップロード -->
 <xsl:template match="dxl:embeddedfileuploadcontrol">
 </xsl:template>
 <!-- ナビゲータの呼び出し -->
 <xsl:template match="dxl:imagemap">
 </xsl:template>
 <!-- スケジューラ -->
 <xsl:template match="dxl:richtextdata[@type='fffd']">
 </xsl:template>

 <!--
 **********************************************************************
 subformref要素
 ********************************************************************** -->
 <xsl:template match="dxl:subformref">
  <!-- サブフォームの計算結果は対象外とする -->
  <xsl:if test="@name">
   <xsl:call-template name="copyNode"/>
  </xsl:if>
 </xsl:template>

 <!--
 **********************************************************************
 表の境界線の色が指定されていない場合
 ********************************************************************** -->
 <xsl:template match="dxl:table/dxl:border[not(@color)]">
  <xsl:element name="{local-name()}">
   <xsl:copy-of select="@*"/>
   <xsl:attribute name="color"><xsl:text>black</xsl:text></xsl:attribute>
  </xsl:element>
 </xsl:template>

 <!--
 **********************************************************************
 表の境界線スタイルがイメージの場合
 ※優先度の兼ね合いから、上記、表の境界線の色が指定されていない場合の
   テンプレートよりも下にある必要があります。
 ********************************************************************** -->
 <xsl:template match="dxl:table/dxl:border[@style='image']">
 </xsl:template>

 <!--
 **********************************************************************
 表のセルに背景イメージが設定されている場合
 ********************************************************************** -->
 <xsl:template match="dxl:cellbackground">
 </xsl:template>

 <!--
 **********************************************************************
 要素をコピーする
 ********************************************************************** -->
 <xsl:template name="copyNode">
  <xsl:element name="{local-name()}">
   <xsl:copy-of select="@*"/>
   <xsl:apply-templates/>
  </xsl:element>
 </xsl:template>

 <!--
 **********************************************************************
 フィールド情報を出力値に変換する
 ********************************************************************** -->
 <xsl:template name="convertField">
  <xsl:param name="value"/>

  <!-- リッチテキストフィールドの場合は接頭辞を付与 -->
  <xsl:variable name="type">
   <xsl:if test="@type='richtext'">
    <xsl:text>richtext:</xsl:text>
   </xsl:if>
  </xsl:variable>

  <xsl:choose>
   <!-- 親要素がrun要素である場合 -->
   <xsl:when test="parent::dxl:run">
    <!-- フィールド名を出力 -->
    <xsl:value-of select="concat($type, $value)"/>
   </xsl:when>
   <!-- 親要素がrun要素でない場合 -->
   <xsl:otherwise>
    <!-- パススルーHTMLにするためにrun要素で囲む -->
    <xsl:element name="run">
     <xsl:attribute name="html"><xsl:text>true</xsl:text></xsl:attribute>
     <xsl:value-of select="concat($type, $value)"/>
    </xsl:element>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <!--
 **********************************************************************
 文字列を置換する
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
 固定文字のみの場合、固定文字を返す
 ********************************************************************** -->
 <xsl:template name="getFixedText">
  <xsl:param name="formula"/>

  <!-- 「@」を含まない場合 -->
  <xsl:if test="not(contains($formula, '@'))">
   <!-- 「"」を含む場合 -->
   <xsl:if test="contains($formula, '&quot;')">
    <!-- 「"」の数を取得 -->
    <xsl:variable name="countOfPlus">
     <xsl:call-template name="getCountOfPlus">
      <xsl:with-param name="formula" select="$formula"/>
      <xsl:with-param name="counter" select="0"/>
     </xsl:call-template>
    </xsl:variable>
    <!-- 「"」の数が2つの場合 -->
    <xsl:if test="number($countOfPlus) = 2">
     <!-- 先頭・末尾が「"」の場合 -->
     <xsl:if test="substring($formula, 1, 1) = '&quot;' and substring($formula, string-length($formula), 1) = '&quot;'">
      <xsl:choose>
       <!-- 「\」を含む場合 -->
       <xsl:when test="contains($formula, '\')">
        <!-- エスケープ文字としての「\」、および先頭・末尾の「"」を除去する -->
        <xsl:call-template name="removeYen">
         <xsl:with-param name="formula" select="substring($formula, 2, string-length($formula) - 2)"/>
        </xsl:call-template>
       </xsl:when>
       <!-- 「\」を含まない場合 -->
       <xsl:otherwise>
        <!-- 先頭・末尾の「"」を除去する -->
        <xsl:value-of select="substring($formula, 2, string-length($formula) - 2)"/>
       </xsl:otherwise>
      </xsl:choose>
     </xsl:if>
    </xsl:if>
   </xsl:if>
  </xsl:if>
 </xsl:template>

 <xsl:template name="getCountOfPlus">
  <xsl:param name="formula"/>
  <xsl:param name="counter"/>
  <xsl:choose>
   <xsl:when test="string-length($formula) &gt; 0">
    <xsl:choose>
     <xsl:when test="substring($formula, 1, 1) = '\'">
      <xsl:call-template name="getCountOfPlus">
       <xsl:with-param name="formula" select="substring($formula, 3, string-length($formula) - 2)"/>
       <xsl:with-param name="counter" select="number($counter)"/>
      </xsl:call-template>
     </xsl:when>
     <xsl:when test="substring($formula, 1, 1) = '&quot;'">
      <xsl:call-template name="getCountOfPlus">
       <xsl:with-param name="formula" select="substring($formula, 2, string-length($formula) - 1)"/>
       <xsl:with-param name="counter" select="number($counter) + 1"/>
      </xsl:call-template>
     </xsl:when>
     <xsl:otherwise>
      <xsl:call-template name="getCountOfPlus">
       <xsl:with-param name="formula" select="substring($formula, 2, string-length($formula) - 1)"/>
       <xsl:with-param name="counter" select="number($counter)"/>
      </xsl:call-template>
     </xsl:otherwise>
    </xsl:choose>
   </xsl:when>
   <xsl:otherwise>
    <xsl:value-of select="$counter"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

 <xsl:template name="removeYen">
  <xsl:param name="formula"/>
  <xsl:choose>
   <xsl:when test="contains($formula, '\')">
    <xsl:value-of select="substring-before($formula, '\')"/>
    <xsl:variable name="formula-after" select="substring-after($formula, '\')"/>
    <xsl:value-of select="substring($formula-after, 1, 1)"/>
    <xsl:variable name="formula-after-length" select="string-length($formula-after)"/>
    <xsl:if test="number($formula-after-length) &gt; 1">
     <xsl:call-template name="removeYen">
      <xsl:with-param name="formula" select="substring($formula-after, 2, string-length($formula-after) - 1)"/>
     </xsl:call-template>
    </xsl:if>
   </xsl:when>
   <xsl:otherwise>
    <xsl:value-of select="$formula"/>
   </xsl:otherwise>
  </xsl:choose>
 </xsl:template>

</xsl:stylesheet>