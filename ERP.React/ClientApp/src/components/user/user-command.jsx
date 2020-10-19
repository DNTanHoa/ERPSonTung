import * as React from "react";

export const UserCommandCell = props => {
  const { dataItem } = props;
  const inEdit = dataItem[props.editField];
  const isNewItem = dataItem.id === 0;

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
        className="btn btn-success mx-1 k-grid-edit-command"
        onClick={() => props.edit(dataItem)}>
        <i className="far fa-edit"></i>
      </button>
      <button
        className="btn btn-success mx-1 k-grid-edit-command"
        onClick={() => props.detail(dataItem)}>
        <i className="fas fa-external-link-alt"></i>
      </button>
      <button
        className="btn btn-danger mx-1 k-grid-remove-command"
        onClick={() =>
          window.confirm("Xác nhận xóa?") &&
          props.remove(dataItem)
        }>
        <i className="fas fa-trash-alt"></i>
      </button>
    </td>
  );
};
