<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCredit.Master" AutoEventWireup="true" CodeBehind="creditTopUp.aspx.cs" Inherits="EADPPROJ.creditTopUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="kt-subheader   kt-grid__item" id="kt_subheader"></div>
                            <div class="row">
                                <div class="col-xl-12">
									<div class="kt-pricing-v2">
                                        <div class="kt-portlet">
											<div class="kt-portlet__body">
												<div class="kt-separator kt-separator--height-xs"></div>
												<h3 class="kt-heading kt-heading--center kt-heading--space-sm kt-heading--xl kt-heading--bolder">Top Up Credit</h3>
												<div class="kt-separator kt-separator--height-sm"></div>
												<div class="kt-align-center">
													<div class="btn-group btn-pill btn-elevated">
														<div class="nav" role="tablist">
															<a class="btn btn-square btn-bold btn-widest btn-taller active show kt-font-transform-u" data-toggle="tab" href="#kt_tabs_3_1" role="tab">Recommend Combo</a>
															<a class="btn btn-square btn-bold btn-widest btn-taller kt-font-transform-u" data-toggle="tab" href="#kt_tabs_3_2" role="tab">Work-To-Me Purchase</a>
														</div>
													</div>
												</div>
												<div class="kt-separator kt-separator--height-md"></div>
												<div class="tab-content">
													<div class="tab-pane active" id="kt_tabs_3_1" role="tabpanel">
														<div class="row">
															<div class="col-lg-12 col-xl-3 col-stretch">
																<div class="kt-pricing-v2__item kt-pricing-v2--flat">
																	<div class="kt-pricing-v2__header">
																		<h3 class="kt-pricing-v2__title">Recommend Combo</h3>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__content">
																			<p>We offer the most popular and substantial combo ofcredit over here!</p>
																			<p>If you are not satisfied, purchase by using Work-To-Me purchase.</p>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-lg-12 col-xl-3 col-stretch kt-pricing-v2--line-right">
																<div class="kt-pricing-v2__item kt-pricing-v2--info kt-pricing-v2--flat">
																	<div class="kt-pricing-v2__header">
																		<div class="kt-iconbox kt-iconbox--no-hover">
																			<div class="kt-iconbox__icon">
																				<div class="kt-iconbox__icon-bg"></div>
																				<i class="flaticon-coins"></i>
																			</div>
																			<div class="kt-iconbox__title">
																				88 Credits + 10 Extra Credits
																			</div>
																		</div>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__price">
																			<div class="kt-pricing-v2__price-currency">S$</div>
                                                                            <div class="kt-pricing-v2__price-value">1</div>
																		</div>
																		<div class="kt-pricing-v2__button">
                                                                            <div id="paypal-button-first"></div>
                                                                            <script src="https://www.paypalobjects.com/api/checkout.js"></script>
                                                                                <script type="text/javascript">
                                                                                    paypal.Button.render({
                                                                                        env: 'sandbox', // production or sandbox 表示产品环境还是测试环境
                                                                                        client: {
                                                                                            sandbox: 'Aav2kq78i4t2bimODiaiuKp3Tm35BOUp-vBvWkNXkLXMXgEWn4GmD7xjV-4Y4_zZ1IxMOQ-Nw3YoYCLQ', // 测试环境，值为字符串，配置商家测试号的 ClientId
                                                                                        },
                                                                                        style: {
                                                                                            size: 'medium',
                                                                                            color: 'black',
                                                                                            shape: 'pill',
                                                                                            label: 'paypal',
                                                                                            tagline: 'false',
                                                                                            fundingicons: 'true'
                                                                                        },
                                                                                        commit: true,
                                                                                        payment: function (data, actions) {
                                                                                            return actions.payment.create({
                                                                                                transactions: [
                                                                                                    {
                                                                                                        amount: {
                                                                                                            total: "1",
                                                                                                            currency: "SGD"
                                                                                                        },
                                                                                                        description: "98 Credits",
                                                                                                        custom: "X00002"
                                                                                                    }
                                                                                                ],
                                                                                                redirect_urls: {
                                                                                                    return_url: 'http://localhost:6965/creditTopUp.aspx?item=first',
                                                                                                    cancel_url: 'http://localhost:6965/creditTopUp.aspx'
                                                                                                }
                                                                                            });
                                                                                        },
                                                                                        onAuthorize: function (data, actions) {
                                                                                            return actions.payment.execute()
                                                                                                .then(function () {
                                                                                                    actions.redirect();
                                                                                                });
                                                                                        },
                                                                                        onCancel: function (data, actions) {
                                                                                            actions.redirect();
                                                                                        }
                                                                                    }, '#paypal-button-first');
                                                                                </script>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-lg-12 col-xl-3 col-stretch">
																<div class="kt-pricing-v2__item kt-pricing-v2--fill-success kt-pricing-v2--flat">
																	<div class="kt-pricing-v2__header">
																		<div class="kt-iconbox kt-iconbox--no-hover">
																			<div class="kt-iconbox__icon">
																				<div class="kt-iconbox__icon-bg"></div>
																				<i class="flaticon-coins"></i>
																			</div>
																			<div class="kt-iconbox__title">
																				888 Credits + 111 Extra Credits
																			</div>
																		</div>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__price">
																			<div class="kt-pricing-v2__price-currency">S$</div>
																			<div class="kt-pricing-v2__price-value">9.9</div>
																		</div>
																		<div class="kt-pricing-v2__button">
                                                                        <div id="paypal-button-second"></div>
                                                                            <script type="text/javascript">
                                                                                paypal.Button.render({
                                                                                    env: 'sandbox', // production or sandbox 表示产品环境还是测试环境
                                                                                    client: {
                                                                                        sandbox: 'Aav2kq78i4t2bimODiaiuKp3Tm35BOUp-vBvWkNXkLXMXgEWn4GmD7xjV-4Y4_zZ1IxMOQ-Nw3YoYCLQ', // 测试环境，值为字符串，配置商家测试号的 ClientId
                                                                                    },
                                                                                    style: {
                                                                                        size: 'medium',
                                                                                        color: 'black',
                                                                                        shape: 'pill',
                                                                                        label: 'paypal',
                                                                                        tagline: 'false',
                                                                                        fundingicons: 'true'
                                                                                    },
                                                                                    commit: true,
                                                                                    payment: function (data, actions) {
                                                                                        return actions.payment.create({
                                                                                            transactions: [
                                                                                                {
                                                                                                    amount: {
                                                                                                        total: "9.9",
                                                                                                        currency: "SGD"
                                                                                                    },
                                                                                                    description: "999 Credits",
                                                                                                    custom: "X00003"
                                                                                                }
                                                                                            ],
                                                                                            redirect_urls: {
                                                                                                return_url: 'http://localhost:6965/creditTopUp.aspx?item=second',
                                                                                                cancel_url: 'http://localhost:6965/creditTopUp.aspx'
                                                                                            }
                                                                                        });
                                                                                    },
                                                                                    onAuthorize: function (data, actions) {
                                                                                        return actions.payment.execute()
                                                                                            .then(function () {
                                                                                                actions.redirect();
                                                                                            });
                                                                                    },
                                                                                    onCancel: function (data, actions) {
                                                                                        actions.redirect();
                                                                                    }
                                                                                }, '#paypal-button-second');
                                                                            </script></div>
																	</div>
																</div>
															</div>
															<div class="col-lg-12 col-xl-3 col-stretch">
																<div class="kt-pricing-v2__item kt-pricing-v2--fill-danger kt-pricing-v2--flat">
																	<div class="kt-pricing-v2__header">
																		<div class="kt-iconbox kt-iconbox--no-hover">
																			<div class="kt-iconbox__icon">
																				<div class="kt-iconbox__icon-bg"></div>
																				<i class="flaticon-coins"></i>
																			</div>
																			<div class="kt-iconbox__title">
																				8888 Credits + 1200 Extra Credits
																			</div>
																		</div>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__price">
																			<div class="kt-pricing-v2__price-currency">S$</div>
																			<div class="kt-pricing-v2__price-value">98</div>
																		</div>
																		<div class="kt-pricing-v2__button">
                                                                         <div id="paypal-button-third"></div>
                                                                            <script type="text/javascript">
                                                                                paypal.Button.render({
                                                                                    env: 'sandbox', // production or sandbox 表示产品环境还是测试环境
                                                                                    client: {
                                                                                        sandbox: 'Aav2kq78i4t2bimODiaiuKp3Tm35BOUp-vBvWkNXkLXMXgEWn4GmD7xjV-4Y4_zZ1IxMOQ-Nw3YoYCLQ', // 测试环境，值为字符串，配置商家测试号的 ClientId
                                                                                    },
                                                                                    style: {
                                                                                        size: 'medium',
                                                                                        color: 'black',
                                                                                        shape: 'pill',
                                                                                        label: 'paypal',
                                                                                        tagline: 'false',
                                                                                        fundingicons: 'true'
                                                                                    },
                                                                                    commit: true,
                                                                                    payment: function (data, actions) {
                                                                                        return actions.payment.create({
                                                                                            transactions: [
                                                                                                {
                                                                                                    amount: {
                                                                                                        total: "98",
                                                                                                        currency: "SGD"
                                                                                                    },
                                                                                                    description: "10088 Credits",
                                                                                                    custom: "X00004"
                                                                                                }
                                                                                            ],
                                                                                            redirect_urls: {
                                                                                                return_url: 'http://localhost:6965/creditTopUp.aspx?item=third',
                                                                                                cancel_url: 'http://localhost:6965/creditTopUp.aspx'
                                                                                            }
                                                                                        });
                                                                                    },
                                                                                    onAuthorize: function (data, actions) {
                                                                                        return actions.payment.execute()
                                                                                            .then(function () {
                                                                                                actions.redirect();
                                                                                            });
                                                                                    },
                                                                                    onCancel: function (data, actions) {
                                                                                        actions.redirect();
                                                                                    }
                                                                                }, '#paypal-button-third');
                                                                            </script></div>
																	</div>
																</div>
															</div>
														</div>
													</div>
													<div class="tab-pane" id="kt_tabs_3_2" role="tabpanel">
														<div class="row">
															<div class="col-lg-12 col-xl-3 col-stretch">
																<div class="kt-pricing-v2__item kt-pricing-v2--elevated">
																	<div class="kt-pricing-v2__header">
																		<h3 class="kt-pricing-v2__title">Work-To-Me Purchase</h3>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__content">
																			<p>Buy credits that fulfill your need.</p>
																			<p>The more credits you purchase, more discount you will have.</p>
																		</div>
																	</div>
																</div>
															</div>
                                                            
															<div class="col-lg-12 col-xl-9 col-stretch kt-pricing-v2--line-right">
																<div class="kt-pricing-v2__item kt-pricing-v2--info kt-pricing-v2--flat">
																	<div class="kt-pricing-v2__header">
																		<div class="kt-iconbox kt-iconbox--no-hover">
																			<div class="kt-iconbox__icon">
																				<div class="kt-iconbox__icon-bg"></div>
																				<i class="flaticon-coins"></i>
																			</div>
																			<div class="kt-iconbox__title">
																				How much you need?
																			</div>
																		</div>
																	</div>
																	<div class="kt-pricing-v2__body">
																		<div class="kt-pricing-v2__price">
																			<div class="form-group form-group-marginless">
													<div class="input-group">
                                                        <asp:TextBox ID="creditNo" CssClass="form-control" aria-describedby="basic-addon2" runat="server"></asp:TextBox>
														<div class="input-group-append"><span class="input-group-text" id="basic-addon2">Credits</span></div>
													</div>
												</div>
																		</div>
																		<div class="kt-pricing-v2__button">
                                                                            <asp:Button ID="RandomCredit" OnClick="RandomCredit_Click" CssClass="btn btn-pill btn-widest btn-taller btn-bold btn-outline" runat="server" Text="Purchase" />
                  
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
        </div>
        </div>
</asp:Content>
