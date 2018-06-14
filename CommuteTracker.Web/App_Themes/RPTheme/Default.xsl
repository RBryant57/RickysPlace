<?xml version="1.0" encoding="iso-8859-1" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" />
  <xsl:template match="/">
    <table border="0" cellspacing="1" align="center" width="100%">
      <xsl:for-each select="Routes/Route">
        <xsl:variable name="routeId">
          <xsl:value-of select="@Id" />
        </xsl:variable>
        <xsl:variable name="amper">
          <xsl:text>&amp;</xsl:text>
        </xsl:variable>
        <xsl:variable name="routeName">
          <xsl:value-of select="@Name" />
        </xsl:variable>
        <tr>
          <font class="MediumLabelStyle">
            <b>
              <a href="CommuteStatisticsDetail.aspx?RouteId={$routeId}{$amper}RouteName={$routeName}">
                <xsl:value-of select="@Name"/>
              </a>
            </b>
          </font>
          <br />
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
                <xsl:value-of select="@RouteMiles"/>
                miles by
                <xsl:value-of select="@RouteType"/>
              </b>
            </li>
            <li>
              <b>
                Commutes:
              </b>
              <xsl:value-of select="Commutes"/>
            </li>
            <br/>
            <xsl:for-each select="Destinations/Destination">
              <br/>
              <font size="Large" >
                <b>
                  <xsl:value-of select="@Name"/>
                </b>
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
                    Average Start Time:
                  </b>
                  <xsl:value-of select="AverageStartTime"/>
                </li>
                <li>
                  <b>
                    Average End Time:
                  </b>
                  <xsl:value-of select="AverageEndTime"/>
                </li>
                <li>
                  <b>
                    Commutes:
                  </b>
                  <xsl:value-of select="Commutes"/>
                </li>
              </ul>
            </xsl:for-each>
            <br/>
            <br/>
          </ul>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>