<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" />
  <xsl:template match="form">
    <html>
      <title>
        <xsl:value-of select="./@name"/>
      </title>
      <xsl:apply-imports/>
    </html>
  </xsl:template>
  <xsl:template match="noteinfo">
    <!--noteinfo
      created:<xsl:value-of select="created/datetime"/>
      modified:<xsl:value-of select="modified/datetime"/>
      revised:<xsl:value-of select="revised/datetime"/>
      lastaccessed:<xsl:value-of select="lastaccessed/datetime"/>
    -->
  </xsl:template>
  <xsl:template match="code">
    <!--
      //notes Script
      <xsl:value-of select="./formula"/>
    -->
  </xsl:template>
  <xsl:template match="actionbar">
    <!--actionbar-->
  </xsl:template>
  <xsl:template match="body">
    <body>
      <xsl:apply-imports/>
    </body>
  </xsl:template>
  <xsl:template match="table">
    <table>
      <xsl:attribute name="border">1</xsl:attribute>
      <xsl:attribute name="style">
        border-collapse:collapse;
        <xsl:choose>
          <xsl:when test="@widthtype='fitmargins'">width:100%</xsl:when>
          <xsl:otherwise>
            <xsl:if test="@refwidth">
              width:<xsl:value-of select="@refwidth"/>;
            </xsl:if>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <xsl:apply-imports/>
    </table>
  </xsl:template>
  <xsl:template match="tablecolumn">
    <col>
      <xsl:attribute name="width">
        <xsl:value-of select="@width"/>
      </xsl:attribute>
    </col>
  </xsl:template>
  <xsl:template match="tablerow">
    <tr>
      <xsl:apply-imports/>
    </tr>
  </xsl:template>
  <xsl:template match="tablecell">
    <td>
      <xsl:apply-imports/>
    </td>
  </xsl:template>
  <xsl:template match="run">
    <span>
      <xsl:apply-templates select="./font"></xsl:apply-templates>
      <xsl:apply-imports/>
    </span>
  </xsl:template>
  <xsl:template name="font">

    <xsl:attribute name="style">
      <xsl:if test="@size">
        font-size:<xsl:value-of select="@size"/>;
      </xsl:if>
      <xsl:if test="@color">
        color:<xsl:value-of select="@color"/>;
      </xsl:if>
      <xsl:if test="@bold='true'">font-weight:bold;</xsl:if>
    </xsl:attribute>
  </xsl:template>
  <xsl:template match="field">
    <xsl:choose>
      <xsl:when test="@type='lable'">
        <span>
          <xsl:value-of select="."/>
        </span>
      </xsl:when>
      <xsl:when test="@type='authors'">
        <input>
          <xsl:attribute name="type">text</xsl:attribute>
          <xsl:if test="@kind">
            <xsl:attribute name="kind">
              <xsl:value-of select="@kind"/>
            </xsl:attribute>
          </xsl:if>
          <xsl:if test="@formula">
            <xsl:attribute name="formula">
              <xsl:value-of select="@formula"/>
            </xsl:attribute>
          </xsl:if>
          <xsl:attribute name="value">
            <xsl:value-of select="@description"/>
          </xsl:attribute>
        </input>
      </xsl:when>
      <xsl:when test="@type='textbox'">
        <input>
          <xsl:attribute name="type">text</xsl:attribute>
          <xsl:attribute name="value">
            <xsl:value-of select="."/>
          </xsl:attribute>
        </input>
      </xsl:when>
      <xsl:when test="@type='checkbox'">
        <input>
          <xsl:attribute name="type">checkbox</xsl:attribute>
          <xsl:if test="@checked='true'">
            <xsl:attribute name="checked">checked</xsl:attribute>
          </xsl:if>
          <xsl:value-of select="."/>
        </input>
      </xsl:when>
      <xsl:when test="@type='fileupload'">
        <input>
          <xsl:attribute name="type">file</xsl:attribute>
        </input>
      </xsl:when>
      <xsl:otherwise>
        <!--サポートしないField-->
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>
