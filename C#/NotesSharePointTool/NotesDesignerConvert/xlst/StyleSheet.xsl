<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dxl="http://www.lotus.com/dxl" dxl:ab="" version="1.0">
  <xsl:output method="html" indent="yes" encoding="UTF-8"/>
  <xsl:template match="/dxl:document">
    <html>
      <head>
        <meta http-equiv="X-UA-Compatible" content="IE=5"/>
        <title>
          <xsl:value-of select="dxl:item[@name=$HtmlTitle]//text()"/>
        </title>
        <script type="text/javascript" src="../../jquery/jquery.min.js"/>
        <script type="text/javascript" src="../../jquery/ui.core.js"/>
        <script type="text/javascript" src="../../jquery/ui.tabs.js"/>
        <link type="text/css" rel="stylesheet" href="../../jquery/ui.tabs.css"/>
        <script type="text/javascript" src="../../jquery/jcaption.min.js"/>
        <script type="text/javascript">
          function section_expand(gid) {
          var c = document.getElementById(gid).style;
          c.display=c.display=='none'?'block':'none';
          var sectiondiv = event.srcElement;
          while(sectiondiv.tagName!='DIV'){
          sectiondiv = sectiondiv.parentElement;
          }
          if(sectiondiv.style.backgroundImage)
          sectiondiv.style.backgroundImage=c.display=='none'?'url(../../domino/section_r.gif)':'url(../../domino/section_d.gif)';
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
        </script>
        <style>
          .Formclass2{
          padding-left:1in;
          line-height:normal;
          text-align:left;
          }

          .Formclass7{
          padding-left:0in;
          line-height:normal;
          text-align:center;
          }

          .Formclass3{
          padding-left:0.7500in;
          line-height:normal;
          text-align:left;
          }

          .Formclass9{
          padding-left:0in;
          line-height:normal;
          text-align:left;
          }

          .Formclass10{
          padding-left:0in;
          line-height:normal;
          text-align:left;
          }

          .Formclass11{
          padding-left:0in;
          line-height:normal;
          text-align:left;
          }

          .Formclass12{
          padding-left:0in;
          line-height:normal;
          text-align:right;
          }

          .Formclass13{
          padding-left:1in;
          line-height:normal;
          text-align:left;
          }

          .defaultclass0{
          padding-left:1in;
          line-height:normal;
          text-align:left;
          }

          <xsl:for-each select="//dxl:pardef">
            <xsl:call-template name="pardef"/>
          </xsl:for-each>
          body{font-size:0pt;
          word-break:break-all;
          font-family: sans-serif;}
          p{font-size:0pt;font-size:0pt; margin:0pt;}
          div{font-size:0pt;margin:0pt;}
          .richtable{border-collapse:collapse;empty-cells:show;table-layout:fixed;}
          .tablecell{ padding:0px;overflow:hidden; }
          .grid{layout-grid-line : 0px;}

          <!-- jcaptionを利用して画像にキャプションを付与する際のスタイル -->
          span.caption p{
          padding:0px 8px;
          font-color:black;
          font-size:9pt;
          text-align:center;
          }

          <!-- Safari対応 キャプションと回り込みの文字が重ならないようにする -->
          @media screen and (-webkit-min-device-pixel-ratio:0){
          span.caption{
          margin-bottom:12px;
          }
          }

        </style>
      </head>
      <body scroll="auto" class="grid">
        <xsl:attribute name="bgcolor">
          <xsl:value-of select="$BgColor"/>
        </xsl:attribute>
        <!-- 
***************************************************************************
フォームレイアウトの記述（ここから）
***************************************************************************-->

        <div class="richtext">


          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <p>
              <font style="font-size:10pt;">&#160;</font>
            </p>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div style="padding-left:0.7500in;">
            <div style="width:100%;">
              <table cellpadding="0" cellspacing="0" class="richtable" style="border-color:black;width:100%;" Align="">
                <colgroup style="width:25.0069%;"/>
                <colgroup style="width:25.0069%;"/>
                <colgroup style="width:25.0069%;"/>
                <colgroup/>
                <tr>
                  <td style="height:0%;"/>
                  <td style="height:0%;"/>
                  <td style="height:0%;"/>
                  <td style="height:0%;"/>
                </tr>
                <tr style="min-height:56.668800000000005;height:56.668800000000005;">
                  <td class="tablecell" valign="top" Colspan="4" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                    <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=#c2efff);background-image:-webkit-linear-gradient(left,navy,#c2efff);">


                      <div class="FormTargetFormclass7" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:36pt;" color="white">
                            <b>DXL出力テストフォーム</b>
                          </font>
                        </p>
                      </div>
                    </span>
                  </td>
                </tr>
              </table>
            </div>
          </div>
          <br/>


          <div class="FormTargetFormclass3" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="padding-left:0.75in;">
            <div onclick="section_expand('N1007A')" style="cursor:pointer;margin-left:0px;padding-left:20px;background:url(../../domino/section_d.gif) no-repeat;zoom:1;">
              <p style="text-indent:0in;border-bottom:solid 1px teal;text-align:left;">
                <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                  <i>メインセクション</i>
                </font>
              </p>
            </div>
          </div>
          <div id="N1007A">
            <div class="FormTargetFormclass2" style="">
              <p>
                <font style="font-size:10pt;">&#160;</font>
              </p>
            </div>
            <div style="padding-left:1in;">
              <div>
                <table cellpadding="0" cellspacing="0" class="richtable" style="border-color:black;width:8.4077in;" Align="">
                  <colgroup style="width:2.1292in;"/>
                  <colgroup style="width:6.2785in;"/>
                  <tr>
                    <td style="height:0%;"/>
                    <td style="height:0%;"/>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">


                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                              <b>テキスト（一行）</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">


                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="monospace" style="white-space:normal;font-size:10pt;" color="black">
                            <u>
                              <xsl:if test="dxl:item[@name='テキスト（一行）']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='テキスト（一行）']"/>
                              </xsl:if>
                            </u>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">


                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                              <b>日付</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <xsl:if test="dxl:item[@name='日付']//text()!=''">
                              <xsl:apply-templates select="dxl:item[@name='日付']"/>
                            </xsl:if>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                              <b>日付・時間</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='日付時間']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='日付時間']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                              <b>数値</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='数値']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='数値']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                              <b>ダイアログリスト</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='ダイアログリスト']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='ダイアログリスト']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>チェックボックス</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='チェックボックス']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='チェックボックス']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>ラジオボタン</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='ラジオボタン']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='ラジオボタン']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>コンボボックス</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='コンボボックス']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='コンボボックス']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>リストボックス</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='無題2']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='無題2']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>リッチテキスト</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                            <b>
                              <xsl:if test="dxl:item[@name='リッチテキスト']//text()!=''">
                                <div>
                                  <xsl:apply-templates select="dxl:item[@name='リッチテキスト']"/>
                                </div>
                              </xsl:if>
                            </b>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>名前</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                            <b>
                              <xsl:if test="dxl:item[@name='名前']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='名前']"/>
                              </xsl:if>
                            </b>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>読者</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                            <b>
                              <xsl:if test="dxl:item[@name='読者']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='読者']"/>
                              </xsl:if>
                            </b>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>パスワード</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                            <b>
                              <xsl:if test="dxl:item[@name='パスワード']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='パスワード']"/>
                              </xsl:if>
                            </b>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>式フィールド（所属）</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="white">
                            <b>
                              <xsl:if test="dxl:item[@name='式フィールド']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='式フィールド']"/>
                              </xsl:if>
                            </b>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass9" style="">
                          <p>
                            <font face="Meiryo UI" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>リッチテキストライト</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='リッチテキストライト']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='リッチテキストライト']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                  <tr>
                    <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                      <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">

                        <div class="FormTargetFormclass11" style="">
                          <p>
                            <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="#e0ffff">
                              <b>色</b>
                            </font>
                          </p>
                        </div>
                      </span>
                    </td>
                    <td class="tablecell" valign="top" style="background-color:;border-color:black;border-style:solid;border-width:1px;">

                      <div class="FormTargetFormclass10" style="">
                        <p>
                          <font face=" sans-serif" style="white-space:normal;font-size:10pt;" color="black">
                            <i>
                              <xsl:if test="dxl:item[@name='色']//text()!=''">
                                <xsl:apply-templates select="dxl:item[@name='色']"/>
                              </xsl:if>
                            </i>
                          </font>
                        </p>
                      </div>
                    </td>
                  </tr>
                </table>
              </div>
            </div>
            <br/>
            <div class="FormTargetFormclass2" style="">
              <p>
                <font style="font-size:10pt;">&#160;</font>
              </p>
            </div>
            <div class="FormTargetFormclass2" style="">
              <p>
                <font style="font-size:10pt;">&#160;</font>
              </p>
            </div>
          </div>
          <div class="FormTargetFormclass2">
            <div style="padding-left:20px;">
              <p style="border-bottom:solid 1px teal;"/>
            </div>
          </div>

          <div class="FormTargetFormclass2" style="">
            <p>
              <font style="font-size:10pt;">&#160;</font>
            </p>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div style="padding-left:1in;">
            <div style="width:100%;">
              <table cellpadding="0" cellspacing="0" class="richtable" style="border-color:black;width:100%;" Align="">
                <colgroup/>
                <tr>
                  <td style="height:0%;"/>
                </tr>
                <tr style="min-height:56.668800000000005;height:56.668800000000005;">
                  <td class="tablecell" valign="top" style="height:100%;border-color:black;border-style:solid;border-width:1px;">
                    <span style="display:inline-block;width:100%;height:100%;filter: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=navy,endColorStr=white);background-image:-webkit-linear-gradient(left,navy,white);">


                      <div class="FormTargetFormclass12" style="">
                        <p>
                          <font face=" sans-serif" style="font-size:10pt;">更新日：</font>
                          <font face=" sans-serif" style="white-space:normal;font-size:9pt;" color="black">
                            <xsl:if test="dxl:item[@name='DateComposed']//text()!=''">
                              <xsl:apply-templates select="dxl:item[@name='DateComposed']"/>
                            </xsl:if>
                          </font>
                          <font face=" sans-serif" style="white-space:normal;font-size:9pt;" color="black">&#160;</font>
                          <font face=" sans-serif" style="white-space:normal;font-size:9pt;" color="black">
                            <xsl:if test="dxl:item[@name='timeComposed']//text()!=''">
                              <xsl:apply-templates select="dxl:item[@name='timeComposed']"/>
                            </xsl:if>
                          </font>
                        </p>
                      </div>
                    </span>
                  </td>
                </tr>
              </table>
            </div>
          </div>
          <br/>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>


          <div class="FormTargetFormclass13" style="">
            <p>
              <font style="font-size:10pt;">&#160;</font>
            </p>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>

          <div class="FormTargetFormclass2" style="">
            <font style="font-size:10pt;">&#65279;</font>
          </div>
        </div>
        <xsl:if test="$OutsideAttachments!=''">
          <xsl:call-template name="OutputOutsideAttachments"/>
        </xsl:if>
        <!-- 
***************************************************************************
フォームレイアウトの記述（ここまで）
***************************************************************************-->
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>