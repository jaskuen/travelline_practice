import { joinClassName } from "../../functions/functions"
import { RateChartType } from "../../types/types"
import styles from "./RateChart.module.css"
import { Line } from 'react-chartjs-2';

type RateChartProps = {
    id: string,
    rateData: RateChartType,
}
const RateChart = (props: RateChartProps) => {
    const {
        id,
        rateData,
    } = props

    const labels = rateData.data.labels
    const options = {
        responsive: true,
        plugins: {
            legend: {
                position: 'top' as const,
            },
            title: {
                display: false,
                text: 'Chart.js Line Chart',
            },
        },
    }
    console.log(rateData.data.datasets[0].data)
    const data = {
        labels,
        datasets: [
          {
            label: 'Dataset 1',
            data: rateData.data.datasets[0].data,
            borderColor: 'rgb(255, 99, 132)',
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
          },
        ],
      };

    return (
        <div className={joinClassName(id, styles.wrapper)}>
            <Line
                options={options} 
                data={data}
            />
        </div>
    )
}   

export {
    RateChart,
}

export type {
    RateChartProps,
}