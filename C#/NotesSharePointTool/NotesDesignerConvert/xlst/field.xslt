<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dxl="http://www.lotus.com/dxl" version="1.0">
    <xsl:output method="xml" indent="yes"/>
  <xsl:template match="dxl:field">
    <xsl:variable name="type"><xsl:value-of select="./@type"/></xsl:variable>
    <xsl:variable name="name"><xsl:value-of select="./@name"/></xsl:variable>
    <xsl:variable name="description"><xsl:value-of select="./@description"/></xsl:variable>
    <xsl:variable name="width"><xsl:value-of select="./@width"/></xsl:variable>
    <xsl:variable name="height"><xsl:value-of select="./@height"/></xsl:variable>
    <xsl:variable name="border"><xsl:value-of select="./@borderstyle"/></xsl:variable>
    <xsl:variable name="kind"><xsl:value-of select="./@kind"/></xsl:variable>
    <xsl:variable name="style">
      <xsl:if test="$width!=''">
        <xsl:text>width:</xsl:text><xsl:value-of select="$width"/><xsl:text>;</xsl:text>
      </xsl:if>
      <xsl:if test="height!=''">
        <xsl:text>height:</xsl:text><xsl:value-of select="$height"/><xsl:text>;</xsl:text>
      </xsl:if>

    </xsl:variable>
    <xsl:choose>
      <xsl:when test="@type='text'">
        <xsl:element name="input">
          <xsl:attribute name="type">text</xsl:attribute>
          <xsl:attribute name="id"><xsl:value-of select="$name"/></xsl:attribute>
          <xsl:attribute name="placeholder"><xsl:value-of select="$description"/></xsl:attribute>
          <xsl:if test="$kind='computed' or $kind='computedfordisplay'">
            <xsl:attribute name="readonly">readonly</xsl:attribute>
          </xsl:if>
          <xsl:if test="$style!=''">
             <xsl:attribute name="style">
               <xsl:value-of select="$style"/>
             </xsl:attribute>
          </xsl:if>
        </xsl:element>
      </xsl:when>
      <xsl:when test="@type='datetime'">
        <xsl:element name="input">
            <xsl:attribute name="type">text</xsl:attribute>  
            <xsl:attribute name="id"><xsl:value-of select="$name"/></xsl:attribute>
            <xsl:attribute name="pattern">[0-9]{4}/[0-9]{1,2}/[0-9]{1,2}</xsl:attribute>  
            <xsl:attribute name="placeholder"><xsl:value-of select="$description"/></xsl:attribute>
        </xsl:element>
      </xsl:when>
      <xsl:when test="@type='richtext'">
        <xsl:element name="textarea">
        <xsl:attribute name="id"><xsl:value-of select="$name"/></xsl:attribute>
        <xsl:attribute name="placeholder"><xsl:value-of select="$description"/></xsl:attribute>
        <xsl:if test="$style!=''">
          <xsl:attribute name="style">
            <xsl:value-of select="$style"/>
          </xsl:attribute>
        </xsl:if>
        <xsl:text>&#160;</xsl:text>
        </xsl:element>
      </xsl:when>
      <xsl:when test="@type='names'">
        <xsl:element name="input">
        <xsl:attribute name="id"><xsl:value-of select="$name"/></xsl:attribute>
        <xsl:attribute name="placeholder"><xsl:value-of select="$description"/></xsl:attribute>
        <xsl:if test="$style!=''">
            <xsl:attribute name="style">
              <xsl:value-of select="$style"/>
            </xsl:attribute>
        </xsl:if>
        </xsl:element>
        <xsl:element name="input">
        <xsl:attribute name="type">button</xsl:attribute>
        <xsl:attribute name="title"><xsl:value-of select="$description"/></xsl:attribute>
        <xsl:attribute name="target"><xsl:value-of select="$name"/></xsl:attribute>
          <xsl:attribute name="value">ユーザー</xsl:attribute>
        </xsl:element>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>
