<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
xmlns:dxl='http://www.lotus.com/dxl'>
<xsl:output method='html'/>
<xsl:strip-space elements='*'/>
  <xsl:template match='dxl:database'>
    <HTML>
      <HEAD>
        <TITLE>
          <xsl:value-of select='@title' />
        </TITLE>
      </HEAD>
      <BODY>
      <xsl:apply-templates/>
      </BODY>
    </HTML>
  </xsl:template>
<xsl:template match='dxl:form'>
  <HR />
  <H1 >
    <xsl:value-of select='@name' />
  </H1>
  <div>
    <xsl:apply-templates/>
  </div>
</xsl:template>
<xsl:template match='dxl:table'>
  <xsl:element name='table'>
    <xsl:attribute name='width'>
      <xsl:choose>
        <xsl:when test=''
      </xsl:choose>
    </xsl:attribute>
  </xsl:element>
</xsl:template>
<xsl:template match='dxl:lotusscript'>
  <div style=" background-color:#EEEEEE; border:1px soild black;width:100%">
    <pre>
      <xsl:apply-templates/>
    </pre>
  </div>
</xsl:template>
</xsl:stylesheet>