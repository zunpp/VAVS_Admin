/**
* @Package: CryptoKit - Crypto Template & Dashboard
* @Version: 1.0.0
*/
jQuery(function ($) {
    'use strict';
    var CRYPTOKIT_SETTINGS = window.CRYPTOKIT_SETTINGS || {}
        ;
    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CRYPTOKIT_SETTINGS.dashboardEcharts = function () {
        /*------------- Chart 1 ----------------*/
        if ($("#browser_type").length) {
            // Initialize after dom ready

            var myChart = echarts.init(document.getElementById('browser_type'));

            $.ajax({
                url: "http://localhost:35351"+ `/Dashboard/GetCashOutHistoryPerMonth`,
                type: 'get',
                success: function (res) {
                    var orders = [];
                    var months = [];
                    for (let i = 0; i < res.length; i++) {

                        months.push(res[i].month);
                        orders.push(res[i].count);


                    }
                    var option = {
                        // Setup grid
                        grid: {
                            zlevel: 0, x: 20, x2: 20, y: 20, y2: 20, borderWidth: 0, backgroundColor: 'rgba(0,0,0,0)', borderColor: 'rgba(0,0,0,0)',
                        }
                        , // Add tooltip
                        tooltip: {
                            trigger: 'axis', axisPointer: {
                                type: 'shadow', // line|shadow
                                lineStyle: {
                                    color: 'rgba(0,0,0,.5)', width: 1
                                }
                                , shadowStyle: {
                                    color: 'rgba(0,0,0,.1)'
                                }
                            }
                        }
                        , // Add legend
                        legend: {
                            data: []
                        }
                        , toolbox: {
                            orient: 'vertical', show: true, showTitle: true, color: ['#bdbdbd', '#bdbdbd', '#bdbdbd', '#bdbdbd'], feature: {
                                mark: {
                                    show: false
                                }
                                , dataZoom: {
                                    show: true, title: {
                                        dataZoom: 'Data Zoom', dataZoomReset: 'Reset Zoom'
                                    }
                                }
                                , dataView: {
                                    show: false, readOnly: true
                                }
                                , magicType: {
                                    show: true, title: {
                                        line: 'Area', bar: 'Bar'
                                    }
                                    , type: ['line', 'bar']
                                }
                                , restore: {
                                    show: false
                                }
                                , saveAsImage: {
                                    show: true, title: 'Save as Image'
                                }
                            }
                        }
                        , // Enable drag recalculate
                        calculable: true, // Horizontal axis
                        xAxis: [{
                            type: 'category', boundaryGap: false, data: months, axisLine: {
                                show: true, onZero: true, lineStyle: {
                                    color: '#e77512', type: 'solid', width: '2', shadowColor: 'rgba(0,0,0,0)', shadowBlur: 5, shadowOffsetX: 3, shadowOffsetY: 3,
                                }
                                ,
                            }
                            , axisTick: {
                                show: false,
                            }
                            , splitLine: {
                                show: false, lineStyle: {
                                    color: '#fff', type: 'solid', width: 0, shadowColor: 'rgba(0,0,0,0)',
                                }
                                ,
                            }
                            ,
                        }
                        ], // Vertical axis
                        yAxis: [{
                            type: 'value', splitLine: {
                                show: false, lineStyle: {
                                    color: 'fff', type: 'solid', width: 0, shadowColor: 'rgba(0,0,0,0)',
                                }
                                ,
                            }
                            , axisLabel: {
                                show: false,
                            }
                            , axisTick: {
                                show: false,
                            }
                            , axisLine: {
                                show: false, onZero: true, lineStyle: {
                                    color: '#ff0000', type: 'solid', width: '0', shadowColor: 'rgba(0,0,0,0)', shadowBlur: 5, shadowOffsetX: 3, shadowOffsetY: 3,
                                }
                                ,
                            }
                            ,
                        }
                        ], // Add series
                        series: [{
                            name: 'Total Pensioner', type: 'line', smooth: true, symbol: 'none', symbolSize: 2, showAllSymbol: true, itemStyle: {
                                normal: {
                                    color: '#e77512', borderWidth: 4, borderColor: '#e77512', areaStyle: {
                                        color: '#e77512', type: 'default'
                                    }
                                }
                            }
                            , data: orders
                        }
                        ]
                    };

                    // Load data into the ECharts instance 
                    myChart.setOption(option);
                }
            });

        }
        if ($("#pie_chart").length) {
            var myChartp = echarts.init(document.getElementById('pie_chart'));
            $.ajax({
                url: "http://localhost:35351" + `/Dashboard/GetFamilyTypeAndPensionerCount`,
                type: 'get',
                success: function (res) {
                  
                    var optionp = {
                        title: {
                            text: '',//Referer of a Website
                            left: ''//center
                        },
                        tooltip: {
                            trigger: 'item'
                        },
                        legend: {
                            orient: 'vertical',
                            left: 'left'
                        },
                        dataset: [
                            {
                                
                                source: [
                                    { value: res.pensionerCount, name: 'Pensioner' },
                                    { value: res.familyTypeCount, name: 'Family Type Pensioner' }
                                ]
                            }
                        ],
                        series: [
                            {
                                type: 'pie',
                                radius: '50%'
                            },
                            {
                                type: 'pie',
                                radius: '50%',
                                label: {
                                    position: 'inside',
                                    formatter: function (val, opts) {
                                        return opts.w.config.series[opts.seriesIndex]
                                    },
                                    color: 'black',
                                    fontSize: 18
                                },
                                //percentPrecision: 0,
                                emphasis: {
                                    label: { show: true },
                                    itemStyle: {
                                        shadowBlur: 10,
                                        shadowOffsetX: 0,
                                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                                    }
                                }
                            }
                        ]
                    };
                    myChartp.setOption(optionp);
                }
            });

        }
        if ($("#pie_chart2").length) {
            var myChartp2 = echarts.init(document.getElementById('pie_chart2'));
            //var colorPalette = ['#00b04f', '#ffbf00', '#ff0000'];
            $.ajax({
                url: "http://localhost:35351" + `/Dashboard/GetPensionerByPensionGroup`,
                type: 'get',
                success: function (res) {
                    var arr = [];
                    for (var i = 0; i < res.length; i++) {
                        var item = { value: res[i].pensionerCount, name: res[i].pensionGroupName };
                        arr.push(item);
                    }
                    var optionp2 = {
                        title: {
                            text: '',//Referer of a Website
                            left: ''//center
                        },
                        tooltip: {
                            trigger: 'item'
                        },
                        legend: {
                            orient: 'vertical',
                            left: 'left'
                        },
                        dataset: [
                            {
                                source:arr
                            }
                        ],
                       color: ['#c23531', '#2f4554', '#61a0a8', '#d48265', '#91c7ae',
                            '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
                        series: [
                            {
                                type: 'pie',
                                radius: '50%'
                            },
                            {
                                type: 'pie',
                                radius: '50%',
                                label: {
                                    position: 'inside',
                                    formatter: function (val, opts) {
                                        return opts.w.config.series[opts.seriesIndex]
                                    },
                                    color: 'black',
                                    fontSize: 18
                                },
                                //percentPrecision: 0,
                                
                                emphasis: {
                                    label: { show: true },
                                    itemStyle: {
                                        shadowBlur: 10,
                                        shadowOffsetX: 0,
                                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                                    }
                                }
                            }
                        ]
                    };
                    myChartp2.setOption(optionp2);
                }
            });

        }
    }
/******************************
 initialize respective scripts 
 *****************************/
$(document).ready(function () {
    CRYPTOKIT_SETTINGS.dashboardEcharts();
}
);
$(window).resize(function () {
    CRYPTOKIT_SETTINGS.dashboardEcharts();
}
);
$(window).load(function () { }
);
}

);