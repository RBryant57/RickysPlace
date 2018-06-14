<?xml version="1.0" encoding="iso-8859-1" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" />
  <xsl:template match="/">
    <table border="0" cellspacing="1" align="center" width="100%">
      <xsl:for-each select="Route">
        <tr>
        <br />
          <ul>
            <xsl:for-each select="Destination">
              <tr>
                <font class="MediumLabelStyle">
                  <b>
                    <xsl:value-of select="@Name" />
                  </b>
                </font>
                <br />
                <ul>
                  <xsl:for-each select="Month">
                    <font class="SmallLabelStyle">
                      <li>
                        <xsl:value-of select="@Month" />
                      </li>
                    </font>
                    <ul>
                      <li>
                        <b>
                          Average Duration:
                        </b>
                        <xsl:value-of select="AverageSeconds"/>
                      </li>
                      <li>
                        <b>
                          Standard Deviation:
                        </b>
                        <xsl:value-of select="StandardDeviation"/>
                      </li>
                      <li>
                        <b>
                          Average Speed:
                        </b>
                        <xsl:value-of select="AverageSpeed"/>
                      </li>
                      <li>
                        <b>
                          Commutes:
                        </b>
                        <xsl:value-of select="Commutes"/>
                      </li>
                    </ul>
                  </xsl:for-each>
                </ul>
              </tr>
            </xsl:for-each>
          </ul>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>