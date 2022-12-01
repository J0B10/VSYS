<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/data">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <body>
                <h1>Demodokument</h1>
                <ul>
                    <xsl:apply-templates />
                </ul>
            </body>
        </html>
    </xsl:template>

    <xsl:template match="person">
        <li xmlns="http://www.w3.org/1999/xhtml">
            <xsl:value-of select="name"/>
        </li>
    </xsl:template>

    <xsl:template match="person[phone]">
        <li xmlns="http://www.w3.org/1999/xhtml">
            <xsl:value-of select="name"/>: <xsl:value-of select="phone/tel[@type='mobil']"/>
        </li>
    </xsl:template>
</xsl:stylesheet>