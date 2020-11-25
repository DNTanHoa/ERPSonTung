import * as React from 'react';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { DropDownList } from '@progress/kendo-react-dropdowns';
import config from '../../appsettings.json';
import { Loading } from '../loading';
import { ToastContainer, toast } from 'react-toastify';
import RecruitmentPlanModal from './recruimentplan-modal';
import { getCategoriesByEntity } from "../../apis/category/category-service";
import { Modal } from 'react-bootstrap';
import { getRecruitmentPlans } from '../../apis/recruitmentplan/recruitmentplan-service';
import { RecruimentPlanCommand } from '../recuirtmentplan/recruitmentplan-command';
import { filterBy } from '@progress/kendo-data-query';

const delay = 300;

let departments = [];

export class RecruitmentPlan extends React.Component {
    constructor(props){
        super(props)

        this.state = {
            skip: 0,
            take: 100,
            showModal: false,
            loading: false,
            recruitmentPlans:[],
            departments:[],
            departmentCode: '',
            keyword: '',
            selectedDataItem: {
                id: 0
            }
        }

        this.handleModalHide = this.handleModalHide.bind(this);
    }

    componentDidMount = async () => {
        this.setState({loading:true});

        departments = await (await getCategoriesByEntity(config.entities.department))
        .map((department) => {return {...department, textname: department.code +' - '+ department.name}});
        
        let recruitmentPlans = await (await getRecruitmentPlans()).map((recruitmentPlan) => {
            return {...recruitmentPlan, startDate: new Date(recruitmentPlan.startDate), endDate: new Date(recruitmentPlan.endDate)}
        });

        this.setState({departments, recruitmentPlans, loading:false})
    }

    CommandCell = props => (
        <RecruimentPlanCommand
            {...props}
            openDetail={this.openDetail}
            remove={this.remove}
            add={this.add}
            discard={this.discard}
            update={this.update}
            cancel={this.cancel}
            editField={this.editField}
        />
    );    

    handleModalHide = () => {
        this.setState({showModal:false})
    }

    handleSelectChange = (e) => {
        this.setState({
            [e.target.name]: e.value.code
        });
    }

    handleSearch = async (e) => {
        this.setState({loading: true});
        
        let keyword = this.state.keyword;

        let recruitmentPlans = await (await getRecruitmentPlans()).map((recruitmentPlan) => {
            return {...recruitmentPlan, startDate: new Date(recruitmentPlan.startDate), endDate: new Date(recruitmentPlan.endDate)}
        });

        console.log(this.state);

        recruitmentPlans = recruitmentPlans.filter((item) => {
            if((item.title.includes(keyword) || item.job.includes(keyword)) && 
            (item.departmentCode === this.state.departmentCode || this.state.departmentCode == '')) {
                return item;
            }
        })

        this.setState({recruitmentPlans, loading: false});
        
    }
   
    handleInputChange = (e) => {
        e.persist();
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleFilterChange = (e) => {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.setState({departments: this.filterEntities(e.filter)});
        }, delay);
    }

    filterEntities(filter) {
        return filterBy(departments, filter);
    }

    pageChange = (event) => {
        this.setState({
            skip: event.page.skip,
            take: event.page.take
        });
    }

    handleGridRowDoubleClick = (e) => {
        this.setState({showModal: true, selectedDataItem: e.dataItem})
    }

    render = () => {
        return(
        <div className="container-fluid">
            <section className="content-header">
                <div className="container-fluid">
                    <div className="row mb-2">
                        <div className="col-sm-6">
                            <h1 className="float-sm-left">Tuyển dụng</h1>
                        </div>
                        <div className="col-sm-6">
                            <ol className="breadcrumb float-sm-right">
                                <li className="breadcrumb-item"><a href="#">Tuyển dụng</a></li>
                                <li className="breadcrumb-item active">Kế hoạch</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </section>
            <section className="content">
                <div className="container-fluid">
                    <div className="row">
                        <div className="card p-1">
                            <div className="card-header p-1">
                                <div className="row w-100 m-0">
                                    <div className="col-md-4 col-lg-3 p-1">
                                        <DropDownList data={this.state.departments} 
                                            textField="textname"
                                            dataItemKey="code"
                                            name="departmentCode"
                                            delay={1000}
                                            filterable={true}
                                            defaultItem = {{code: '', textname: '--Tất cả bộ phận--'}}
                                            onFilterChange={this.handleFilterChange}
                                            value={this.state.department}
                                            onChange={this.handleSelectChange}
                                            style={{width: '100%'}}/>
                                    </div>
                                    <div className="col-md-3 col-lg-3 mt-1 mt-md-0 p-1">
                                            <input className="form-control" name="keyword" onChange={this.handleInputChange} placeholder="Tìm...."></input>
                                        </div>
                                    <div className="col-md-1 col-12 mt-1 mt-md-0 p-1">
                                        <button className="btn btn-success w-100" title="Tìm kết quả" onClick={this.handleSearch}>
                                            <i className="fas fa-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div className="card-body p-1">
                                <Grid style={{ height: "550px" }}
                                    resizable={true}
                                    reorderable={true}
                                    onPageChange={this.pageChange}
                                    onRowDoubleClick={this.handleGridRowDoubleClick}
                                    total={this.state.recruitmentPlans.length}
                                    skip={this.state.skip}
                                    pageable={{buttonCount: 5, info: true, pageSizes:true}}
                                    data={this.state.recruitmentPlans.slice(this.state.skip, this.state.take + this.state.skip)}>
                                    <GridToolbar>
                                        <div className="d-flex">
                                            <button className="btn btn-success"
                                                onClick={() => {this.setState({selectedDataItem: { id: 0 }}); this.setState({showModal: true})}}
                                                title="Thêm kế hoạch">
                                                <i className="fas fa-plus-circle"></i>
                                            </button>
                                            <button className="btn btn-success ml-1"
                                                onClick={this.handleSearch}
                                                title="Tải lại">
                                                <i className="fas fa-sync"></i>
                                            </button>
                                        </div>
                                    </GridToolbar>
                                    <Column cell={this.CommandCell} width="120px"/>
                                    <Column field="code" title="Mã số" width="120px" editable={false} />
                                    <Column field="title" title="Tiêu đề" width="250px" />
                                    <Column field="quantity" title="Số lượng" width="150px"/>
                                    <Column field="job" title="Vị trí" width="250px" />
                                    <Column field="department" title="Bộ phận" width="250px" />
                                    <Column field="startDate" title="Từ ngày" width="150px" format="{0:dd-MM-yyyy}"/>
                                    <Column field="displayStatus" title="Trạng thái" width="150px" />
                                    <Column field="endDate" title="Đến ngày" width="150px" format="{0:dd-MM-yyyy}"/>
                                    <Column field="note" title="Ghi chú"/>
                                </Grid>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            {this.state.loading === true ? <Loading></Loading> : null} 
            <Modal centered={true} 
                size="xl"
                onHide={this.handleModalHide}
                enforceFocus={false}
                show={this.state.showModal}>
                <RecruitmentPlanModal onHide={this.handleModalHide} 
                    dataItem={this.state.selectedDataItem}/>
            </Modal>
        </div>
        )
    }
}