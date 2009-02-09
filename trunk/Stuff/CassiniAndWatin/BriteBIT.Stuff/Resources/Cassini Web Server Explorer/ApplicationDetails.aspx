<%@ Page language="c#" Codebehind="ApplicationDetails.aspx.cs" AutoEventWireup="false" Inherits="CassiniExplorer.ApplicationDetails" trace="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cassini ASP.Net Application Details</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link rel="stylesheet" href="Main.css">
			<script language="JavaScript" type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
			</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout" bgcolor="#e1e1e1" leftmargin="0" topmargin="0" marginwidth="0"
		marginheight="0" onLoad="MM_preloadImages('images/register-main-over.gif','images/about-main-over.gif','images/ultidev-main-over.gif','images/register2.gif','images/register2-2.gif','images/about2-2.gif','images/ultidev2.gif')">
		<form id="Form1" method="post" runat="server">
			<table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="16" align="left" valign="top"><img src="images/top.gif" width="800" height="16"></td>
				</tr>
				<tr>
					<td align="left" valign="top"><a href="http://www.ultidev.com" target="_blank"><img src="images/banner.gif" width="800" height="58" border="0"></a></td>
				</tr>
				<tr>
					<td align="left" valign="top"><table width="800" border="0" cellspacing="0" cellpadding="0">
							<tr align="left" valign="top">
								<!-- Top Navbar -->
								<td width="252"><a href="http://www.ultidev.com" target="_blank"><img src="images/logo-text.gif" width="252" height="31" border="0"></a></td>
								<td width="36"><img src="images/register2.gif" name="registerleft" width="36" height="31" id="registerleft"></td>
								<td width="144"><img src="images/register-main-over.gif" name="register" width="144" height="31" border="0"></td>
								<td width="36"><img src="images/register2-1.gif" name="registerside" width="36" height="31" id="registerside"></td>
								<td width="135"><a href="http://www.ultidev.com/products/Cassini" target="_blank" onMouseOver="MM_swapImage('registerside','','images/register2-2.gif','about','','images/about-main-over.gif','aboutside','','images/about2-1.gif',1)"
										onMouseOut="MM_swapImgRestore()"><img src="images/about-main.gif" name="about" width="135" height="31" border="0"></a></td>
								<td width="36"><img src="images/about1-1.gif" name="aboutside" width="36" height="31" id="aboutside"></td>
								<td width="135"><a href="http://www.ultidev.com" target="_blank"><img src="images/ultidev-main.gif" name="ultidev" width="135" height="31" border="0"
											onMouseOver="MM_swapImage('aboutside','','images/about1-2.gif','ultidev','','images/ultidev-main-over.gif','ultidevside','','images/ultidev2.gif',1)"
											onMouseOut="MM_swapImgRestore()"></a></td>
								<td><img src="images/ultidev1.gif" name="ultidevside" width="26" height="31" id="ultidevside"></td>
								<!-- End of Top Navbar -->
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="left" valign="top"><img src="images/middle.gif" width="800" height="21"></td>
				</tr>
				<tr>
					<td align="left" valign="top"><table width="800" border="0" cellspacing="0" cellpadding="0">
							<tr align="left" valign="top">
								<td width="18"><img src="images/left.gif" width="18" height="261"></td>
								<td width="756" bgcolor="#ffffff"><table width="756" border="0" cellspacing="0" cellpadding="0">
										<TR>
											<TD width="28"></TD>
											<TD valign="middle" width="700" bgColor="whitesmoke" height="50"><H2 align="right">
													Application Details&nbsp;&nbsp;
												</H2>
											</TD>
											<TD width="28"></TD>
										</TR>
										<tr align="left" valign="top">
											<td width="28"><img src="images/pix.gif" width="28" height="1"></td>
											<td width="700" align="center">
												<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="ErrorSummary" DESIGNTIMEDRAGDROP="64"
													Width="100%"></asp:validationsummary>
												<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
													<TR id="pickFileRow" runat="server">
														<TD vAlign="middle" noWrap align="right">
															<asp:Label id="pickFileLabel" runat="server">Pick Default Document:</asp:Label></TD>
														<TD vAlign="top" noWrap><INPUT id="filePick" type="file" runat="server" NAME="filePick" size="42" class="TextBox">&nbsp;<INPUT id="hiddenFilePath" type="hidden" name="hiddenFilePath" runat="server"></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">Port:</TD>
														<TD vAlign="top" noWrap><asp:radiobutton id="ephemeralPortRadioButton" runat="server" GroupName="Port Selection" Text="System assigned"
																AutoPostBack="True" ToolTip="Select to make Cassini automatically assing a port when you click Save."></asp:radiobutton><BR>
															<asp:radiobutton id="explicityPortRadioButton" runat="server" GroupName="Port Selection" Text="Specify Port"
																AutoPostBack="True"></asp:radiobutton>&nbsp;
															<asp:textbox id=portTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].Port") %>' Visible="False" Columns="5" MaxLength="5" ToolTip="TCP Port number" CssClass="TextBox">
															</asp:textbox>
															<asp:CustomValidator id="portNumberCustomValidator" runat="server" ErrorMessage="Please enter valid port number between 1 and 65535."
																Display="Dynamic" ControlToValidate="portTextBox" EnableClientScript="False">?</asp:CustomValidator>
															<asp:CustomValidator id="portAvailabilityCustomValidator" runat="server" ErrorMessage="This port is already in use. Please select different port."
																Display="Dynamic" ControlToValidate="portTextBox" EnableClientScript="False">?</asp:CustomValidator></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">Name:</TD>
														<TD vAlign="top" noWrap><asp:textbox id=nameTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].Name") %>' MaxLength="50" ToolTip="Application name" Columns="41" CssClass="TextBox">
															</asp:textbox></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">Description:</TD>
														<TD vAlign="top" noWrap><asp:textbox id=descriptionTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].Description") %>' MaxLength="512" Columns="84" CssClass="TextBox"></asp:textbox></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">ID:</TD>
														<TD vAlign="bottom" noWrap><asp:textbox id=appIdTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].ApplicationID") %>' Columns="41" ToolTip="Application ID" MaxLength="40" CssClass="TextBox"></asp:textbox>
															<asp:RequiredFieldValidator id="appIdRequiredFieldValidator" runat="server" ErrorMessage="Application ID must be specified. You can generate a new one by clicking Generate button."
																Display="Dynamic" ControlToValidate="appIdTextBox">*</asp:RequiredFieldValidator>
															<asp:RegularExpressionValidator id="appIdRegularExpressionValidator" runat="server" ControlToValidate="appIdTextBox"
																Display="Dynamic" ErrorMessage="Application ID should have a format of Globally Unique Identifier" ValidationExpression="[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}">?</asp:RegularExpressionValidator>
															<asp:ImageButton id="generateGuidImageButton" runat="server" CausesValidation="False" ImageUrl="images/buttons/generate.gif"
																ToolTip="Generate new identity for the application"></asp:ImageButton></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">Physical Location:</TD>
														<TD vAlign="top" noWrap>
															<asp:textbox id=physicalPathTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].PhysicalPath") %>' Columns="84" ToolTip="Folder where web application is located" MaxLength="512" CssClass="TextBox">
															</asp:textbox>
															<asp:RequiredFieldValidator id="phyicalLocationRequiredFieldValidator" runat="server" ControlToValidate="physicalPathTextBox"
																Display="Dynamic" ErrorMessage="Application folder must be specified" EnableClientScript="False">*</asp:RequiredFieldValidator>
															<asp:CustomValidator id="physicalPathCustomValidator" runat="server" ControlToValidate="physicalPathTextBox"
																Display="Dynamic" ErrorMessage="Specified folder does not exist on the server machine.">?</asp:CustomValidator></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right" height="26">Default Document:</TD>
														<TD vAlign="top" noWrap height="26"><asp:textbox id=defaultDocumentTextBox runat="server" Text='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].DefaultDocument") %>' ToolTip="Application default document. Can be left blank if it's Default.aspx or Index.htm." MaxLength="80" Columns="41" CssClass="TextBox"></asp:textbox>
															<asp:CustomValidator id="defaultDocumentCustomValidator" runat="server" Display="Dynamic" ErrorMessage="Default document file was not found in the specified folder."
																ControlToValidate="defaultDocumentTextBox">?</asp:CustomValidator></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right">Target&nbsp;ASP.NET Version:</TD>
														<TD vAlign="top" noWrap>
															<asp:DropDownList id="clrVersionDropDownList" runat="server" CssClass="TextBox"></asp:DropDownList></TD>
													</TR>
													<TR>
														<TD vAlign="middle" noWrap align="right"></TD>
														<TD vAlign="top" noWrap>
															<asp:CheckBox id=keepRunningCheckBox runat="server" Text="Always keep application in memory to improve first page response time" Checked='<%# DataBinder.Eval(applicationsDataSet, "Tables[CassiniApplications].DefaultView.[0].KeepRunning") %>'>
															</asp:CheckBox></TD>
													</TR>
													<TR>
														<TD vAlign="top" noWrap align="right"></TD>
														<TD vAlign="top" noWrap><BR>
															&nbsp;
															<asp:ImageButton id="submitImageButton" runat="server" ImageUrl="images/buttons/save.gif"></asp:ImageButton>
															<asp:ImageButton id="cancelImageButton" runat="server" CausesValidation="False" ImageUrl="images/buttons/cancel.gif"></asp:ImageButton></TD>
													</TR>
												</TABLE>
											</td>
											<td width="28"><img src="images/pix.gif" width="28" height="1"></td>
										</tr>
									</table>
								</td>
								<td width="26" background="images/right.gif"><img src="images/right.gif" width="26" height="261"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="left" valign="top"><img src="images/bottom.gif" width="800" height="49"></td>
				</tr>
				<tr>
					<td align="left" valign="top"><table width="800" border="0" cellspacing="0" cellpadding="0">
							<tr align="left" valign="top">
								<td width="48"><img src="images/pix.gif" width="60" height="1"></td>
								<td width="680" align="right"><div class="footer">© UltiDev LLC, All rights 
										reserved.&nbsp;Using&nbsp;this software constitutes accpetance of <A href="Cassini EULA.rtf">
											License Agrrement</A> terms.
									</div>
								</td>
								<td width="61"><img src="images/pix.gif" width="60" height="1"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
