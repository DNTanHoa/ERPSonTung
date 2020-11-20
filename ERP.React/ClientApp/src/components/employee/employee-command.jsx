import * as React from "react";

export const EmployeeCommandCell = props => {
  const { dataItem } = props;
  const inEdit = dataItem[props.editField];
  const isNewItem = dataItem.ID === 0;

  return inEdit ? (
    <td className="k-command-cell">
      <button className="btn btn-primary mx-1 k-grid-save-command"
            onClick={() => (isNewItem ? props.add(dataItem) : props.update(dataItem))}>
        <i className="far fa-save"></i>
      </button>
      <button
        className="btn btn-dark mx-1 k-grid-cancel-command"
        onClick={() => (isNewItem ? props.discard(dataItem) : props.cancel(dataItem))}>
        <i className="fas fa-ban"></i>
      </button>
    </td>
  ) : (
    <td className="k-command-cell">
      <button
        title="Xem hồ sơ chi tiết"
        className="btn btn-success mx-1 k-grid-edit-command"
        onClick={() => props.openDetail(dataItem)}>
        <i className="fas fa-external-link-square-alt"></i>
      </button>
      <button
        title="Xóa hồ sơ nhân viên"
        className="btn btn-danger mx-1 k-grid-remove-command"
        onClick={() =>
          window.confirm("Xác nhận xóa: " + dataItem.displayName) &&
          props.remove(dataItem)
        }>
        <i className="fas fa-trash-alt"></i>
      </button>
    </td>
  );
};
