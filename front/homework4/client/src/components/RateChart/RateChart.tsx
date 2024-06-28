import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend, ChartData,
    Point,
    TooltipItem,
    Chart
  } from 'chart.js';
import { Line } from 'react-chartjs-2';
import { generateUID, joinClassName } from "../../functions/functions"
import styles from "./RateChart.module.css"
import { useEffect, useState } from 'react';
import { TimeRangePanel } from './TimeRangePanel/TimeRangePanel';
import { RateChartProps } from '../../types/types';

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
)

type TimeRange = '1' | '2' | '3' | '4' | '5'

const RateChart = (props: RateChartProps) => {
    const {
        id,
        rateData,
    } = props

    const [timeRange, setTimeRange] = useState<TimeRange>("5")
    const [data, setData] = useState<ChartData<"line", (number | Point | null)[], unknown> | undefined>(rateData ? rateData : undefined)

    useEffect(() => {
        if (data && rateData) {
            setData({
                ...data, 
                labels: rateData.labels ? rateData.labels.filter((price, index, data) => index >= (data.length - Number(timeRange) * 6)) : [],
                datasets: [{
                    ...data.datasets[0],
                    data: rateData.datasets[0].data.filter((price, index, data) => index >= (data.length - Number(timeRange) * 6)),
                }]
            })
        }
        
    }, [timeRange, rateData])

    const options = {
        responsive: true,
        plugins: {
            legend: {
                display: false,
                position: 'top' as const,
            },
            title: {
                display: false,
                text: 'Chart.js Line Chart',
            },

        },
        scales: {
            x: {
                ticks: {
                    display: false,
                }
            }
        },
        tooltips: {
            enabled: true,
            callbacks: {
              label: function(tooltipItem: TooltipItem<'line'>, data: ChartData) {
                return tooltipItem.formattedValue;
              }
            }
          }
    }

    return (
        <div className={id ? joinClassName(id, styles.wrapper) : styles.wrapper}>
            <TimeRangePanel id={generateUID()} onChange={setTimeRange}/>
            <div className={styles.chartWrapper}>
                {data ?
                    <Line
                        options={options} 
                        data={data}
                    />
                    : <div>error getting data</div>
                }
            </div>
        </div>
    )
}   

export {
    RateChart,
}

export type {
    RateChartProps,
    TimeRange,
}