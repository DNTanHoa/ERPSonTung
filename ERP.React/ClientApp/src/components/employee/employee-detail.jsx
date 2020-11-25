import React, { useEffect, useRef, useState } from "react";
import { DatePicker } from "@progress/kendo-react-dateinputs";
import { TabStrip, TabStripTab } from "@progress/kendo-react-layout";
import "./employee-detail.css";
import {
  Grid,
  GridColumn as Column,
  GridToolbar,
} from "@progress/kendo-react-grid";
import { useHistory, useLocation } from "react-router-dom";
import { getCategoriesByEntity } from "../../apis/category/category-service";
import config from "../../appsettings.json";
import { DropDownList } from "@progress/kendo-react-dropdowns";
import {
  getById,
  saveEmployeeDetail,
} from "../../apis/employee/employee-service";
import { getModelTemplates } from "../../apis/employee/employee-service";
import { Loading } from "../loading";
import { buildFormData } from "../../utils/ulti-helper";

export const EmployeeDetail = () => {
  const history = useHistory();

  const location = useLocation();

  const [selected, setSelected] = useState(Number);
  const [isBusy, setBusy] = useState(true);
  const [avatar, setAvartar] = useState("");

  const [selectedFile, setSelectedFile] = useState(null);
  const inputFile = useRef(null);

  const [departments, setDepartments] = useState([]);
  const [department, setDepartment] = useState({});

  const [employeeStatuses, setEmployeeStatuses] = useState([]);
  const [employeeStatus, setEmployeeStatus] = useState({});

  const [jobs, setJobs] = useState([]);
  const [job, setJob] = useState({});

  const [groups, setGroups] = useState([]);
  const [group, setGroup] = useState({});

  const [positions, setPositions] = useState([]);
  const [position, setPosition] = useState({});

  const [laborGroups, setLaborGroups] = useState([]);
  const [laborGroup, setLaborGroup] = useState({});

  const [supervisors, setSupervisors] = useState([]);
  const [supervisor, setSupervisor] = useState({});

  const [employee, setEmployee] = useState({});

  const handleTabSelect = (e) => {
    setSelected(e.selected);
  };

  const loadDepartments = async () => {
    let data = (await getCategoriesByEntity(config.entities.department)).map(
      (department) => {
        return {
          ...department,
          textname: department.code + " - " + department.name,
        };
      }
    );

    return data;
  };

  const loadEmployeeStatuses = async () => {
    let data = (
      await getCategoriesByEntity(config.entities.employeeStatus)
    ).map((employeeStatus) => {
      return {
        ...employeeStatus,
        textname: employeeStatus.code + " - " + employeeStatus.name,
      };
    });
    return data;
  };

  const loadJobs = async () => {
    let data = (await getCategoriesByEntity(config.entities.job)).map((job) => {
      return { ...job, textname: job.code + " - " + job.name };
    });
    return data;
  };

  const loadGroups = async () => {
    let data = (await getCategoriesByEntity(config.entities.group)).map(
      (group) => {
        return { ...group, textname: group.code + " - " + group.name };
      }
    );
    return data;
  };

  const loadPositions = async () => {
    let data = (await getCategoriesByEntity(config.entities.position)).map(
      (position) => {
        return { ...position, textname: position.code + " - " + position.name };
      }
    );
    return data;
  };

  const loadLaborGroups = async () => {
    let data = (await getCategoriesByEntity(config.entities.laborGroup)).map(
      (laborGroup) => {
        return {
          ...laborGroup,
          textname: laborGroup.code + " - " + laborGroup.name,
        };
      }
    );
    return data;
  };

  const loadEmployee = async (id) => {
    let data = await getById(id);
    return data;
  };

  const loadSupervisors = async () => {
    let data = await getModelTemplates();
    return data;
  };

  const handleChange = (e) => {
    const { name, value } = e.target;

    switch (name) {
      case "departmentCode":
        setDepartment({ ...department, ...value });
        setEmployee({ ...employee, [name]: value.code });

        break;

      case "groupCode":
        setGroup({ ...group, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "statusCode":
        setEmployeeStatus({ ...employeeStatus, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "jobCode":
        setJob({ ...job, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "positionCode":
        setPosition({ ...position, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "laborGroupCode":
        setLaborGroup({ ...laborGroup, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "supervisorCode":
        setSupervisor({ ...supervisor, ...value });
        setEmployee({ ...employee, [name]: value.code });
        break;

      case "startDate":
        var formatDate = value.toISOString();
        setEmployee({ ...employee, [name]: formatDate });
        break;

      case "dateOfBirth":
        var formatDate = value.toISOString();
        setEmployee({ ...employee, [name]: formatDate });
        break;

      default:
        setEmployee({ ...employee, [name]: value });
        break;
    }
  };

  const handleClickExit = () => {
    history.push("/hrm/employee");
  };

  const handleClickUpload = (e) => {
    inputFile.current.click();
  };

  const fileHandle = (e) => {
    setSelectedFile(e.target.files[0]);
    let reader = new FileReader();
    reader.onload = function (e) {
      setAvartar(e.target.result);
    };
    reader.readAsDataURL(e.target.files[0]);
  };

  const handleClickSaveEmployee = async (typeSubmit) => {
    let formData = new FormData();

    if (selectedFile !== null) {
      formData.append("image", selectedFile, selectedFile.name);
    }

    buildFormData(formData, employee, null);

    await saveEmployeeDetail(formData);
  };

  useEffect(() => {
    if (location.state === undefined) {
      history.push("/hrm/employee");
    } else {
      const load = async () => {
        let departments = await loadDepartments();
        let employeeStatuses = await loadEmployeeStatuses();
        let jobs = await loadJobs();
        let groups = await loadGroups();
        let positions = await loadPositions();
        let laborGroups = await loadLaborGroups();
        let employee = await loadEmployee(location.state.id);
        let supervisors = await loadSupervisors();

        setDepartments(departments);
        let department = departments.find(
          (n) => n.code === employee.departmentCode
        );
        setDepartment(department);

        setEmployeeStatuses(employeeStatuses);
        let employeeStatus = employeeStatuses.find(
          (n) => n.code === employee.statusCode
        );
        setEmployeeStatus(employeeStatus);

        setJobs(jobs);
        let job = jobs.find((n) => n.code === employee.jobCode);
        setJob(job);

        setGroups(groups);
        let group = groups.find((n) => n.code === employee.groupCode);
        setGroup(group);

        setPositions(positions);
        let position = positions.find((n) => n.code === employee.positionCode);
        setPosition(position);

        setLaborGroups(laborGroups);
        let laborGroup = laborGroups.find(
          (n) => n.code === employee.laborGroupCode
        );
        setPosition(laborGroup);

        setSupervisors(supervisors);
        let supervisor = laborGroups.find(
          (n) => n.code === employee.supervisorCode
        );
        setSupervisor(supervisor);

        var startDate = new Date(employee.startDate).toISOString().slice(0, 10);
        var dateOfBirth = new Date(employee.dateOfBirth)
          .toISOString()
          .slice(0, 10);

        setEmployee({
          ...employee,
          startDate: startDate,
          dateOfBirth: dateOfBirth,
        });

        setAvartar(
          employee.image === null ? "/images/avatar.png" : employee.image
        );

        setBusy(false);
      };

      setTimeout(() => {
        load();
      }, 1000);
    }
  }, [location, history]);

  if (isBusy) {
    return <Loading />;
  } else {
    return (
      <div>
        <div className="container-fluid">
          <section className="content-header">
            <div className="container-fluid px-1">
              <div className="row mb-2">
                <div className="card w-100">
                  <div className="card-header">
                    <div className="row">
                      <p className="col-sm-6 px-1 mt-1 mb-0">
                        Thông tin nhân viên
                      </p>
                      <div className="col-md-6 px-1 py-1 py-md-0">
                        <button
                          className="btn btn-primary mx-1 float-md-right float-sm-left"
                          title="Lưu thay đổi"
                          onClick={() => handleClickSaveEmployee(1)}
                        >
                          <i className="far fa-save"></i>
                        </button>
                        <button
                          className="btn btn-warning mx-1 float-md-right float-sm-left text-white"
                          title="Lưu và tạo mới"
                        >
                          <i className="far fa-save"></i>
                        </button>
                        <button
                          className="btn btn-success mx-1 float-md-right float-sm-left"
                          title="Lưu và thoát"
                        >
                          <i className="far fa-save"></i>
                        </button>
                        <button
                          className="btn btn-dark mx-1 float-md-right float-sm-left"
                          title="Thoát"
                          onClick={handleClickExit}
                        >
                          <i className="fas fa-arrow-left"></i>
                        </button>
                      </div>
                    </div>
                  </div>
                  <div className="card-body">
                    <div className="row">
                      <div className="col-md-4 col-lg-2 text-center p-1">
                        <img
                          alt="avatar"
                          src={avatar}
                          style={{ height: "160px", width: "160px" }}
                        ></img>
                        <div className="input-group mt-md-5 mt-1">
                          <input
                            type="text"
                            className="form-control"
                            placeholder="Upload hình ảnh"
                          />
                          <input
                            type="file"
                            hidden
                            ref={inputFile}
                            onChange={fileHandle}
                            accept="image/*"
                          />
                          <div className="input-group-append">
                            <button
                              className="btn btn-success"
                              onClick={handleClickUpload}
                            >
                              <i className="fas fa-cloud-upload-alt"></i>
                            </button>
                          </div>
                        </div>
                      </div>
                      <div className="col-md-3 col-lg-5 p-1">
                        <div className="row">
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="firstName">
                                Họ và đệm
                              </label>
                              <input
                                name="firstName"
                                type="text"
                                className="form-control"
                                placeholder="Họ tên đệm"
                                value={employee.firstName || ""}
                                onChange={handleChange}
                              ></input>
                            </div>
                          </div>
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="lastName">
                                Tên
                              </label>
                              <input
                                name="lastName"
                                type="text"
                                className="form-control"
                                placeholder="Tên"
                                value={employee.lastName || ""}
                                onChange={handleChange}
                              ></input>
                            </div>
                          </div>
                        </div>
                        <div className="row">
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="code">
                                Mã
                              </label>
                              <input
                                name="code"
                                type="text"
                                className="form-control"
                                placeholder="Mã"
                                value={employee.code || ""}
                                onChange={handleChange}
                              ></input>
                            </div>
                          </div>
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="checkInOutCode">
                                Chấm công
                              </label>
                              <input
                                name="checkInOutCode"
                                type="text"
                                className="form-control"
                                placeholder="Chấm công"
                                onChange={handleChange}
                                value={employee.checkInOutCode || ""}
                              ></input>
                            </div>
                          </div>
                        </div>
                        <div className="row">
                          <div className="col-6">
                            <label className="m-0" htmlFor="startDate">
                              Vào làm
                            </label>
                            <DatePicker
                              name="startDate"
                              format="dd-MM-yyyy"
                              className="w-100"
                              onChange={handleChange}
                              defaultValue={new Date(employee.startDate)}
                            />
                          </div>
                          <div className="col-6">
                            <label className="m-0" htmlFor="dateOfBirth">
                              Ngày sinh
                            </label>
                            <DatePicker
                              name="dateOfBirth"
                              format="dd-MM-yyyy"
                              className="form-control"
                              defaultValue={new Date(employee.dateOfBirth)}
                              onChange={handleChange}
                            />
                          </div>
                        </div>
                        <div className="form-group m-0">
                          <label className="m-0" htmlFor="statusCode">
                            Trạng thái
                          </label>
                          <DropDownList
                            data={employeeStatuses}
                            textField="textname"
                            dataItemKey="code"
                            name="statusCode"
                            delay={1000}
                            filterable={true}
                            value={employeeStatus}
                            onChange={handleChange}
                            style={{ width: "100%" }}
                          />
                        </div>
                      </div>
                      <div className="col-md-5 p-1">
                        <div className="row">
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="departmentCode">
                                Bộ phận
                              </label>
                              <DropDownList
                                data={departments}
                                textField="textname"
                                dataItemKey="code"
                                name="departmentCode"
                                filterable={true}
                                value={department}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="groupCode">
                                Tổ
                              </label>
                              <DropDownList
                                data={groups}
                                textField="textname"
                                dataItemKey="code"
                                name="groupCode"
                                delay={1000}
                                filterable={true}
                                value={group}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                        </div>
                        <div className="row">
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="positionCode">
                                Chức vụ
                              </label>
                              <DropDownList
                                data={positions}
                                textField="textname"
                                dataItemKey="code"
                                name="positionCode"
                                delay={1000}
                                filterable={true}
                                value={position}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="jobCode">
                                Công việc
                              </label>
                              <DropDownList
                                data={jobs}
                                textField="textname"
                                dataItemKey="code"
                                name="jobCode"
                                delay={1000}
                                filterable={true}
                                value={job}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                        </div>
                        <div className="row">
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="laborGroupCode">
                                Nhóm lao động
                              </label>
                              <DropDownList
                                data={laborGroups}
                                textField="textname"
                                dataItemKey="code"
                                name="laborGroupCode"
                                delay={1000}
                                filterable={true}
                                value={laborGroup}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                          <div className="col-6">
                            <div className="form-group m-0">
                              <label className="m-0" htmlFor="supervisorCode">
                                Quản lý
                              </label>
                              <DropDownList
                                data={supervisors}
                                textField="display"
                                dataItemKey="code"
                                name="supervisorCode"
                                delay={1000}
                                filterable={true}
                                value={supervisor}
                                onChange={handleChange}
                                style={{ width: "100%" }}
                              />
                            </div>
                          </div>
                        </div>
                        <div className="form-group m-0">
                          <label className="m-0" htmlFor="Code">
                            Ghi chú
                          </label>
                          <input
                            type="text"
                            className="form-control"
                            placeholder="Ghi chú"
                          ></input>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="row mb-md-1 mb-1">
                <div className="card w-100" style={{ overflowX: "auto" }}>
                  <div className="card-header">
                    <h3 className="card-title">Thông tin liên quan</h3>
                  </div>
                  <div className="card-body w-100">
                    <TabStrip
                      selected={selected}
                      onSelect={handleTabSelect}
                      className="w-100"
                    >
                      <TabStripTab title="1.Liên hệ" className="w-100">
                        <div className="container-fluid w-100">
                          <div className="row">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Thường trú
                              </label>
                            </div>
                            <div className="col-md-10 col-lg-11">
                              <div className="input-group mb-2">
                                <input
                                  type="text"
                                  className="form-control"
                                  placeholder="Địa chỉ thường trú"
                                />
                                <div className="input-group-append">
                                  <button className="btn btn-success">
                                    <i className="fas fa-map-marker-alt"></i>
                                  </button>
                                </div>
                              </div>
                            </div>
                          </div>
                          <div className="row">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Trạm trú
                              </label>
                            </div>
                            <div className="col-md-10 col-lg-11">
                              <div className="input-group mb-2">
                                <input
                                  type="text"
                                  className="form-control"
                                  placeholder="Địa chỉ tạm trú"
                                />
                                <div className="input-group-append">
                                  <button className="btn btn-success">
                                    <i className="fas fa-map-marker-alt"></i>
                                  </button>
                                </div>
                              </div>
                            </div>
                          </div>
                          <div className="row mb-md-2 mb-0">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Điện thoại
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Điện thoại"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Email
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Email công ty"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Email (phụ)
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Email cá nhân"
                              />
                            </div>
                          </div>
                          <div className="row mb-md-2 mb-0">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                CMND
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Chứng minh, căn cước, hộ chiếu"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Ngày Cấp
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Ngày cấp"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Nơi cấp
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Nơi cấp"
                              />
                            </div>
                          </div>
                          <div className="row mb-md-2 mb-0">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Giới tính
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Giới tính"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Dân tộc
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Ngày cấp"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Tôn giáo
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Tôn giáo"
                              />
                            </div>
                          </div>
                          <div className="row mb-md-2 mb-0">
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Tài khoản
                              </label>
                            </div>
                            <div className="col-md-2 col-lg-3">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Giới tính"
                              />
                            </div>
                            <div className="col-md-2 col-lg-1">
                              <label className="text-nowrap m-0 mr-2 mt-md-1">
                                Ngân hàng
                              </label>
                            </div>
                            <div className="col-md-6 col-lg-7">
                              <input
                                type="text"
                                className="form-control w-100"
                                placeholder="Tên ngân hàng"
                              />
                            </div>
                          </div>
                        </div>
                      </TabStripTab>
                      <TabStripTab title="2.Hợp đồng">
                        <Grid style={{ height: "350px" }}>
                          <GridToolbar>
                            <button
                              className="btn btn-success"
                              title="Thêm thành viên"
                            >
                              <i className="fas fa-plus-circle"></i>
                            </button>
                          </GridToolbar>
                          <Column
                            field="code"
                            title="Mã số"
                            width="200px"
                            editable={false}
                          />
                          <Column
                            field="fullName"
                            title="Đại diên"
                            width="250px"
                          />
                          <Column
                            field="startDate"
                            title="Loại hợp đồng"
                            width="150px"
                          />
                          <Column
                            field="status"
                            title="Trạng thái"
                            width="150px"
                          />
                          <Column
                            field="dateOfBirth"
                            title="Ngày ký"
                            width="150px"
                            format="dd-MM-yyyy"
                          />
                          <Column
                            field="dateOfBirth"
                            title="Ngày hiệu lực"
                            width="150px"
                            format="dd-MM-yyyy"
                          />
                          <Column
                            field="dateOfBirth"
                            title="Ngày hết hạn"
                            width="150px"
                            format="dd-MM-yyyy"
                          />
                          <Column field="note" title="Ghi chú" />
                        </Grid>
                      </TabStripTab>
                      <TabStripTab title="3.Bảo hiểm">
                        <Grid style={{ height: "350px" }}>
                          <GridToolbar>
                            <button
                              className="btn btn-success"
                              title="Thêm thành viên"
                            >
                              <i className="fas fa-plus-circle"></i>
                            </button>
                          </GridToolbar>
                          <Column
                            field="code"
                            title="Mã số"
                            width="200px"
                            editable={false}
                          />
                          <Column
                            field="fullName"
                            title="Số sổ"
                            width="250px"
                          />
                          <Column
                            field="fullName"
                            title="Ngày đóng"
                            width="250px"
                          />
                          <Column
                            field="fullName"
                            title="Nởi đăng ký KCB"
                            width="250px"
                          />
                          <Column field="note" title="Số thẻ BHYT" />
                        </Grid>
                      </TabStripTab>
                      <TabStripTab title="4.Nghỉ phép">
                        <Grid style={{ height: "350px" }}>
                          <GridToolbar>
                            <button
                              className="btn btn-success"
                              title="Thêm thành viên"
                            >
                              <i className="fas fa-plus-circle"></i>
                            </button>
                          </GridToolbar>
                          <Column
                            field="code"
                            title="STT"
                            width="100px"
                            editable={false}
                          />
                          <Column
                            field="fullName"
                            title="Ngày nghỉ"
                            width="150px"
                          />
                          <Column
                            field="fullName"
                            title="Bắt đầu"
                            width="150px"
                          />
                          <Column
                            field="fullName"
                            title="Két thúc"
                            width="150px"
                          />
                          <Column
                            field="fullName"
                            title="Lý do"
                            width="250px"
                          />
                          <Column
                            field="note"
                            title="Phê duyệt"
                            width="100px"
                          />
                          <Column field="note" title="Người phê duyệt" />
                          <Column field="note" title="Ghi chú" />
                        </Grid>
                      </TabStripTab>
                      <TabStripTab title="5.Lịch sử"></TabStripTab>
                      <TabStripTab title="6.Hồ sơ"></TabStripTab>
                      <TabStripTab title="7.Người thân"></TabStripTab>
                      <TabStripTab title="8.Khen thưởng - kỷ luật"></TabStripTab>
                    </TabStrip>
                  </div>
                </div>
              </div>
            </div>
          </section>
        </div>
      </div>
    );
  }
};

export default EmployeeDetail;
