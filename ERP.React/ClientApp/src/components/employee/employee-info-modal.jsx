import React from "react";
import { Modal } from "react-bootstrap";
import { DatePicker } from "@progress/kendo-react-dateinputs";
import { DropDownList } from "@progress/kendo-react-dropdowns";
import { getCategoriesByEntity } from "../../apis/category/category-service";
import config from "../../appsettings.json";
import EmployeeService from "../../apis/employee/employee-service";
import { buildFormData } from "../../utils/ulti-helper";
import { toast } from "react-toastify";

export default class EmployeeInfoModal extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      employee: {
        id: 0,
        firstName: "",
        lastName: "",
        code: "",
        checkInOutCode: "",
        startDate: new Date().toISOString().slice(0, 10),
        dateOfBirth: new Date().toISOString().slice(0, 10),
        departmentCode: "",
        groupCode: "",
        jobCode: "",
        laborGroupCode: "",
        positionCode: "",
        supervisorCode: "",
        statusCode: "",
      },
      departments: [],
      department: null,
      employeeStatuses: [],
      employeeStatus: null,
      groups: [],
      group: null,
      jobs: [],
      job: null,
      positions: [],
      position: null,
      laborGroups: [],
      laborGroup: null,
      supervisors: [],
      supervisor: null,
      defaultItem: {
        textname: "----Chọn----",
        display: "----Chọn----",
        code: null,
      },
    };

    this.handleChange = this.handleChange.bind(this);
  }

  componentDidMount = async () => {
    let departments = await (
      await getCategoriesByEntity(config.entities.department)
    ).map((department) => {
      return {
        ...department,
        textname: department.code + " - " + department.name,
      };
    });

    let employeeStatuses = await (
      await getCategoriesByEntity(config.entities.employeeStatus)
    ).map((employeeStatus) => {
      return {
        ...employeeStatus,
        textname: employeeStatus.code + " - " + employeeStatus.name,
      };
    });

    let jobs = await (await getCategoriesByEntity(config.entities.job)).map(
      (job) => {
        return { ...job, textname: job.code + " - " + job.name };
      }
    );

    let groups = await (await getCategoriesByEntity(config.entities.group)).map(
      (group) => {
        return { ...group, textname: group.code + " - " + group.name };
      }
    );

    let positions = await (
      await getCategoriesByEntity(config.entities.position)
    ).map((position) => {
      return { ...position, textname: position.code + " - " + position.name };
    });

    let laborGroups = await (
      await getCategoriesByEntity(config.entities.laborGroup)
    ).map((laborGroup) => {
      return {
        ...laborGroup,
        textname: laborGroup.code + " - " + laborGroup.name,
      };
    });

    let supervisors = await EmployeeService.getModelTemplates();

    this.setState({
      departments,
      employeeStatuses,
      jobs,
      groups,
      positions,
      laborGroups,
      supervisors,
    });
  };

  handleChange = (event) => {
    let name = event.target.name;
    let value = event.target.value;

    switch (name) {
      case "departmentCode":
        this.setState({
          department: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });

        break;

      case "groupCode":
        this.setState({
          group: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });

        break;

      case "statusCode":
        this.setState({
          employeeStatus: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });

        break;

      case "jobCode":
        this.setState({
          job: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });

        break;

      case "positionCode":
        this.setState({
          position: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });
        break;

      case "laborGroupCode":
        this.setState({
          laborGroup: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });
        break;

      case "supervisorCode":
        this.setState({
          supervisor: event.value,
          employee: {
            ...this.state.employee,
            [name]: value.code,
          },
        });
        break;

      case "startDate":
        if (value !== null) {
          let startDate = value.toISOString().slice(0, 10);
          this.setState({
            employee: {
              ...this.state.employee,
              [name]: startDate,
            },
          });
        }
        break;

      default:
        this.setState({
          employee: {
            ...this.state.employee,
            [name]: value,
          },
        });

        break;
    }
  };

  handleClickSave = async () => {
      
    let formData = new FormData();

    buildFormData(formData, this.state.employee, null);

    await EmployeeService.saveEmployeeDetail(formData)
      .then((response) => {
        if (response.data.result.resultType === 0) {
          this.props.onHide();
          toast.success("Cập nhật thành công", 2000);
        } else {
          let errorArr = response.data.result.message.split(";");

          if (errorArr.length === 0) {
            toast.error(response.data.result.message, 2000);
          } else {
            for (let index = 0; index < errorArr.length; index++) {
              let message = errorArr[index];
              toast.error(message, 2000);
            }
          }
        }
      })
      .catch((error) => {
        toast.error(error, 2000);
      });
  };

  render = () => {
    return (
      <>
        <Modal.Header>
          <h5 className="modal-title">Thông tin nhân viên</h5>
        </Modal.Header>
        <Modal.Body>
          <div className="row mb-1">
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Mã quản lý</label>
                <input
                  className="form-control"
                  placeholder="Mã quản lý"
                  name="code"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Họ và đệm</label>
                <input
                  className="form-control"
                  placeholder="Họ và tên đệm"
                  name="firstName"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Tên</label>
                <input
                  className="form-control"
                  placeholder="Tên"
                  name="lastName"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>
          </div>
          <div className="row mb-1">
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Mã chấm công</label>
                <input
                  className="form-control"
                  placeholder="Mã chấm công"
                  name="checkInOutCode"
                  onChange={this.handleChange}
                ></input>
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Ngày vào</label>
                <DatePicker
                  format="dd-MM-yyyy"
                  className="w-100"
                  defaultValue={new Date()}
                  name="startDate"
                  onChange={this.handleChange}
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Trạng thái</label>
                <DropDownList
                  data={this.state.employeeStatuses}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="statusCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.employeeStatus}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
          </div>
          <div className="row mb-1">
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Bộ phận</label>
                <DropDownList
                  data={this.state.departments}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="departmentCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.department}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Tổ nhóm</label>
                <DropDownList
                  data={this.state.groups}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="groupCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.group}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Công việc</label>
                <DropDownList
                  data={this.state.jobs}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="jobCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.job}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
          </div>
          <div className="row mb-1">
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Chức vụ</label>
                <DropDownList
                  data={this.state.positions}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="positionCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.position}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Nhóm lao động</label>
                <DropDownList
                  data={this.state.laborGroups}
                  defaultItem={this.state.defaultItem}
                  textField="textname"
                  dataItemKey="code"
                  name="laborGroupCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.laborGroup}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="form-group m-0">
                <label className="m-0">Người quản lý</label>
                <DropDownList
                  data={this.state.supervisors}
                  defaultItem={this.state.defaultItem}
                  textField="display"
                  dataItemKey="code"
                  name="supervisorCode"
                  delay={1000}
                  filterable={true}
                  value={this.state.supervisor}
                  onChange={this.handleChange}
                  style={{ width: "100%" }}
                />
              </div>
            </div>
          </div>
          <div className="row mb-1">
            <div className="col-sm-12">
              <div className="form-group m-0">
                <label className="m-0">Ghi chú</label>
                <input className="form-control" placeholder="Ghi chú"></input>
              </div>
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer>
          <div className="row w-100">
            <div className="col-5 col-md-6 p-0">
              <button className="btn btn-success float-sm-left">
                <i className="far fa-question-circle"></i> Trợ giúp
              </button>
            </div>
            <div className="col-7 col-md-6 p-0">
              <div className="float-right d-flex">
                <button
                  className="btn btn-primary"
                  onClick={this.handleClickSave}
                >
                  <i className="far fa-save"></i> Lưu
                </button>
                <button
                  className="btn btn-danger ml-1"
                  onClick={this.props.onHide}
                >
                  <i className="far fa-times-circle"></i> Thoát
                </button>
              </div>
            </div>
          </div>
        </Modal.Footer>
      </>
    );
  };
}
